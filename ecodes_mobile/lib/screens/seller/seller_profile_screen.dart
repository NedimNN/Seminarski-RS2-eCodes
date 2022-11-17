import 'package:ecodes_mobile/model/rating.dart';
import 'package:ecodes_mobile/model/seller.dart';
import 'package:ecodes_mobile/providers/cart_provider.dart';
import 'package:ecodes_mobile/providers/product_provider.dart';
import 'package:ecodes_mobile/providers/rating_provider.dart';
import 'package:ecodes_mobile/providers/seller_provider.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/product.dart';
import '../../utils/util.dart';
import '../products/product_details_screen.dart';

class SellerProfileScreen extends StatefulWidget {
  static const String routeName = "/seller_profile";
  String id;

  SellerProfileScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<SellerProfileScreen> createState() => _SellerProfileScreenState();
}

class _SellerProfileScreenState extends State<SellerProfileScreen> {
  SellerProvider? _sellerProvider = null;
  ProductProvider? _productProvider = null;
  CartProvider? _cartProvider = null;
  RatingProvider? _ratingProvider = null;
  Seller _seller = new Seller();
  List<Product> _productList = [];
  List<Rating> _ratingList = [];
  String nav = "Shop";
  final DateFormat formatter = DateFormat('yyyy-MM-dd');
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _sellerProvider = context.read<SellerProvider>();
    _productProvider = context.read<ProductProvider>();
    _cartProvider = context.read<CartProvider>();
    _ratingProvider = context.read<RatingProvider>();
    loadSeller(this.widget.id);
  }

  void loadSeller(String id) async {
    var identity = int.parse(id);
    var tempSeller = await _sellerProvider?.getById(identity);
    var productSearchRequest = {
      'StateMachine': 'active',
      'IncludeType': true,
      'sellerName': tempSeller?.name
    };
    var ratingSearchRequest = {'sellerId': identity};
    var tempProducts = await _productProvider?.get(productSearchRequest);
    var tempRatings = await _ratingProvider?.get(ratingSearchRequest);
    setState(() {
      _seller = tempSeller!;
      _productList = tempProducts!;
      _ratingList = tempRatings!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
      selectedIndex: 1,
      child: Stack(
        children: [
          Container(
            decoration: BoxDecoration(
                image: DecorationImage(
                    fit: BoxFit.fill,
                    image: AssetImage("assets/images/giftcards_image.png"))),
          ),
          SingleChildScrollView(
              child: Container(
            child: _buildSellerProfile(),
          )),
        ],
      ),
    );
  }

  Widget _buildHeader() {
    if (_seller.name == null) {
      return Container(
        margin: EdgeInsets.all(15),
        child: Center(
            child: Text(
          "Loading...",
          style: Theme.of(context).textTheme.headline6,
        )),
      );
    }
    return Column(
      children: [
        Container(
          margin: EdgeInsets.all(10),
          child: Text(
            _seller.name!,
            style: Theme.of(context).textTheme.headline6,
          ),
        ),
        Container(
      height: 78,
      child: GridView(
          gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
              crossAxisCount: 1,
              childAspectRatio: 1 / 5,
              crossAxisSpacing: 5,
              mainAxisSpacing: 5),
          scrollDirection: Axis.horizontal,
          children: [
            Container(
              margin: EdgeInsets.only(top: 5, bottom: 5, right: 5, left: 5),
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.all(Radius.circular(15)),
              ),
              child: Center(
                child: Text("Phone Number: ${_seller.phoneNumber}",
                    style: Theme.of(context).textTheme.bodyText1),
              ),
            ),
            Container(
              margin: EdgeInsets.only(top: 5, bottom: 5, right: 5, left: 5),
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.all(Radius.circular(15)),
              ),
              child: Center(
                child: Text("Address: ${_seller.address}",
                    style: Theme.of(context).textTheme.bodyText1),
              ),
            ),
            Container(
              margin: EdgeInsets.only(top: 5, bottom: 5, right: 5, left: 5),
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.all(Radius.circular(15)),
              ),
              child: Center(
                child: Text("Website: ${_seller.website}",
                    style: Theme.of(context).textTheme.bodyText1),
              ),
            )
          ]),
    )
      ],
    );
  }

  Widget _buildNav() {
    var selected = false;
    return Container(
      decoration: BoxDecoration(
        color: Color.fromARGB(195, 31, 173, 238),
        borderRadius: BorderRadius.all(Radius.circular(25)),
      ),
      margin: EdgeInsets.only(left: 15, right: 15),
      padding: EdgeInsets.only(top: 10, bottom: 10),
      child: Row(
        children: [
          Container(
            width: (MediaQuery.of(context).size.width / 2) - 15,
            child: InkWell(
              child: Center(child: _buildNavHelper("Shop")),
              onTap: () {
                setState(() {
                  nav = "Shop";
                });
              },
            ),
          ),
          Container(
            width: (MediaQuery.of(context).size.width / 2) - 15,
            child: InkWell(
              child: Center(child: _buildNavHelper("Ratings")),
              onTap: () {
                setState(() {
                  nav = "Ratings";
                });
              },
            ),
          )
        ],
      ),
    );
  }

  Widget _buildNavHelper(String text) {
    if (nav == text) {
      return Text(
        text,
        style: TextStyle(color: Colors.amber[300]),
      );
    } else {
      return Text(
        text,
        style: TextStyle(color: Colors.white),
      );
    }
  }

  List<Widget> _buildSellerShopOrRating() {
    if (_productList.isEmpty) {
      return [
        Container(
          margin: EdgeInsets.all(15),
          child: Center(
              child: Text(
            "Loading...",
            style: Theme.of(context).textTheme.headline6,
          )),
        )
      ];
    }
    if (nav == "Ratings") {
      List<Widget> listRating = _ratingList
          .map((x) => Container(
                margin: EdgeInsets.all(15),
                child: Container(
                  decoration: BoxDecoration(
                    color: Color.fromARGB(213, 31, 172, 238),
                    borderRadius: BorderRadius.circular(25),
                  ),
                  padding: EdgeInsets.all(15),
                  child: Column(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Text(
                            style: Theme.of(context).textTheme.bodyText1,
                            "This user bought: ${x.product!.name} ${x.product!.productType!.name} ${x.product!.price} ${x.product!.productType!.currency!.abbreviation}"),
                        Divider(
                          color: Colors.white,
                          thickness: 2,
                        ),
                        Text(
                            style: Theme.of(context).textTheme.bodyText1,
                            "Username: ${x.buyer!.username!}"),
                        RatingBarIndicator(
                            rating: x.mark!,
                            itemCount: 5,
                            itemBuilder: (context, index) {
                              switch (index) {
                                case 0:
                                  return Icon(
                                    Icons.sentiment_very_dissatisfied,
                                    color: Colors.red,
                                  );
                                case 1:
                                  return Icon(
                                    Icons.sentiment_dissatisfied,
                                    color: Colors.redAccent,
                                  );
                                case 2:
                                  return Icon(
                                    Icons.sentiment_neutral,
                                    color: Colors.amber,
                                  );
                                case 3:
                                  return Icon(
                                    Icons.sentiment_satisfied,
                                    color: Colors.lightGreen,
                                  );
                                case 4:
                                  return Icon(
                                    Icons.sentiment_very_satisfied,
                                    color: Colors.green,
                                  );
                              }
                              return Container(
                                padding: EdgeInsets.only(left: 25),
                                child: Text(
                                    style:
                                        Theme.of(context).textTheme.subtitle2,
                                    "Loading..."),
                              );
                            }),
                        Divider(
                          color: Colors.white,
                          thickness: 2,
                        ),
                        Container(
                          child: Text(
                              style: Theme.of(context).textTheme.bodyText1,
                              "Description:\n${x.description!}"),
                        ),
                        Divider(
                          color: Colors.white,
                          thickness: 2,
                        ),
                        Text(
                            style: Theme.of(context).textTheme.subtitle1,
                            "Date of rating: ${formatter.format(x.date!).toString()}"),
                      ]),
                ),
              ))
          .cast<Widget>()
          .toList();

      return listRating;
    }
    List<Widget> list = _productList
        .map((x) => Container(
              decoration: BoxDecoration(
                color: Color.fromARGB(195, 31, 173, 238),
                borderRadius: BorderRadius.all(Radius.circular(25)),
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Flexible(
                    child: InkWell(
                      onTap: () {
                        Navigator.pushNamed(context,
                            "${ProductDetailsScreen.routeName}/${x.productId}");
                      },
                      child: Container(
                          margin: EdgeInsets.only(top: 8),
                          height: 250,
                          child: imageFromBase64String(x.picture!)),
                    ),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Text(
                              style: Theme.of(context).textTheme.bodyText1,
                              x.name ?? ""),
                          Text(
                              style: Theme.of(context).textTheme.bodyText1,
                              formatNumber(x.price) +
                                  " " +
                                  x.productType!.currency!.abbreviation!),
                        ],
                      ),
                      IconButton(
                        onPressed: () {
                          _cartProvider?.addToCart(x);
                        },
                        icon: Icon(
                            color: Colors.white, Icons.shopping_bag_rounded),
                        iconSize: 55,
                      ),
                    ],
                  )
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }

  Widget _buildSellerProfile() {
    // TODO: implement SellerProfile
    return Container(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        mainAxisSize: MainAxisSize.min,
        children: [
          _buildHeader(),
          Flexible(
            fit: FlexFit.loose,
            child: Divider(
              color: Colors.grey,
              thickness: 2,
            ),
          ),
          _buildNav(),
          Flexible(
            fit: FlexFit.loose,
            child: Divider(
              color: Colors.grey,
              thickness: 2,
            ),
          ),
          Container(
            margin: EdgeInsets.all(16),
            child: GridView(
              shrinkWrap: true,
              scrollDirection: Axis.vertical,
              physics: ScrollPhysics(),
              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 1, mainAxisSpacing: 16, crossAxisSpacing: 16),
              children: _buildSellerShopOrRating(),
            ),
          ),
          Flexible(
            fit: FlexFit.loose,
            child: Divider(
              color: Colors.grey,
              thickness: 2,
            ),
          ),
        ],
      ),
    );
  }
}
