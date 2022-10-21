import 'package:ecodes_mobile/model/product.dart';
import 'package:ecodes_mobile/model/rating.dart';
import 'package:ecodes_mobile/providers/rating_provider.dart';
import 'package:ecodes_mobile/providers/user_provider.dart';
import 'package:ecodes_mobile/screens/user/user_profile_details_screen.dart';
import 'package:ecodes_mobile/utils/util.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:collection/collection.dart';

import '../../providers/cart_provider.dart';
import '../../providers/product_provider.dart';

class ProductDetailsScreen extends StatefulWidget {
  static const String routeName = "/product_details";
  String id;

  ProductDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ProductDetailsScreen> createState() => _ProductDetailsScreenState();
}

class _ProductDetailsScreenState extends State<ProductDetailsScreen> {
  ProductProvider? _productProvider = null;
  CartProvider? _cartProvider = null;
  RatingProvider? _ratingProvider = null;

  final DateFormat formatter = DateFormat('yyyy-MM-dd');

  Product _product = new Product();
  List<Rating> _ratings = [];
  List<Product> _recommendedProducts = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    _cartProvider = context.read<CartProvider>();
    _ratingProvider = context.read<RatingProvider>();
    loadProduct(this.widget.id);
  }

  void loadProduct(String id) async {
    var identity = int.parse(id);
    var tmpproduct = await _productProvider?.getById(identity);
    var tmprecommended = await _productProvider?.getRecommended(identity);
    setState(() {
      _product = tmpproduct!;
      _recommendedProducts = tmprecommended!;
      loadRatings(_product.productId!);
    });
  }

  void loadRatings(int id) async {
    var searchRequest = {'ProductId': id};
    var ratings = await _ratingProvider?.get(searchRequest);
    setState(() {
      _ratings = ratings!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
        selectedIndex: 0,
        child: SingleChildScrollView(
          child: Container(
            child: _buildProductDetails(),
          ),
        ));
  }

  Widget _buildProductDetails() {
    if (_product.picture == null) {
      return Center(
        child: Text("Loading...", style: Theme.of(context).textTheme.headline6),
      );
    }
    var productPic = _product.picture;
    return Container(
      decoration: BoxDecoration(
          image: DecorationImage(
              fit: BoxFit.fill,
              image: AssetImage("assets/images/giftcards_image.png"))),
      child: Column(
        children: [
          Container(
            margin: EdgeInsets.only(top: 10),
            child: Text(
              _product.name!,
              style: Theme.of(context).textTheme.headline2,
            ),
          ),
          Container(
            height: 545,
            width: 400,
            margin: EdgeInsets.fromLTRB(25, 15, 25, 15),
            padding: EdgeInsets.all(15),
            decoration: BoxDecoration(
              color: Colors.blue,
              borderRadius: BorderRadius.circular(35),
            ),
            child: ClipRRect(
                borderRadius: BorderRadius.circular(35),
                child: SizedBox.fromSize(
                  size: Size.fromRadius(48), // Image radius
                  child: imageFromBase64String(productPic!),
                )),
          ),
          Center(
            child: Container(
              padding: EdgeInsets.all(25),
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.all(Radius.circular(25)),
              ),
              child: Text(
                _product.description!,
                style: Theme.of(context).textTheme.bodyText1,
              ),
            ),
          ),
          _buildProductInfo(),
          _buildSellerInfo(),
          _buildAddToCartandPrice(),
          Divider(
            color: Colors.white,
            thickness: 5,
          ),
          Container(
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.all(Radius.circular(25)),
              ),
              padding: EdgeInsets.all(10),
              margin: EdgeInsets.only(top: 10),
              child: Text(
                "User ratings",
                style: Theme.of(context).textTheme.headline3,
              )),
          Column(
            children: _buildRatingsForProduct(),
          ),
          Divider(
            color: Colors.white,
            thickness: 5,
          ),
          Container(
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.all(Radius.circular(25)),
              ),
              padding: EdgeInsets.all(10),
              margin: EdgeInsets.only(top: 10,bottom: 10 ),
              child: Text(
                "Recommended products",
                style: Theme.of(context).textTheme.headline3,
              )),
          Container(
            height: 178,
            margin: EdgeInsets.only(top: 10,bottom: 10 ),
            child: GridView(
              shrinkWrap: true,
              scrollDirection: Axis.horizontal,
              physics: ScrollPhysics(),
              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 1,
                childAspectRatio: 1,
                crossAxisSpacing: 5,
                mainAxisSpacing: 5),
              children: _buildRecommendedProdcuts(),
            ),
          )
        ],
      ),
    );
  }

  Widget _buildProductInfo() {
    return Container(
      height: 75,
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
                child: Text("Product Type: ${_product.productTypeName!}",
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
                child: Text("Duration: ${_product.duration!}",
                    style: Theme.of(context).textTheme.bodyText1),
              ),
            )
          ]),
    );
  }

  Widget _buildSellerInfo() {
    return Container(
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
                child: Text("Seller name: ${_product.seller!.name}",
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
                child: Text("Phone Number: ${_product.seller!.phoneNumber}",
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
                child: Text("Address: ${_product.seller!.address}",
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
                child: Text("Website: ${_product.seller!.website}",
                    style: Theme.of(context).textTheme.bodyText1),
              ),
            )
          ]),
    );
  }

  Widget _buildAddToCartandPrice() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Container(
          margin: EdgeInsets.only(right: 30, bottom: 5),
          padding: EdgeInsets.all(15),
          width: 135,
          decoration: BoxDecoration(
            color: Colors.blue,
            borderRadius: BorderRadius.all(Radius.circular(15)),
          ),
          child: Center(
            child: Text(
              _product.price!.toString()+" "+_product.productType!.currency!.abbreviation!.toString(),
              style: Theme.of(context).textTheme.bodyText1,
            ),
          ),
        ),
        Container(
          margin: EdgeInsets.only(bottom: 5),
          child: SizedBox(
            height: 53,
            width: 150,
            child: ElevatedButton.icon(
              onPressed: () {
                _cartProvider?.addToCart(_product);
              },
              icon: Icon(
                Icons.shopping_cart_checkout_outlined,
                size: 24.0,
              ),
              label: Text('Add to Cart'),
              style: ButtonStyle(),
            ),
          ),
        ),
      ],
    );
  }

  List<Widget> _buildRatingsForProduct() {
    if (_ratings.isEmpty) {
      return [
        Text(style: Theme.of(context).textTheme.headline6, "Loading.....")
      ];
    }

    List<Widget> list = _ratings
        .map((x) => Container(
              margin: EdgeInsets.all(15),
              child: Container(
                decoration: BoxDecoration(
                  color: Color.fromARGB(192, 4, 104, 150),
                  borderRadius: BorderRadius.circular(25),
                ),
                padding: EdgeInsets.all(15),
                child: Column(children: [
                  Text(
                      style: Theme.of(context).textTheme.bodyText1,
                      x.buyer!.username!),
                  Divider(
                    color: Colors.white,
                    thickness: 2,
                  ),
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
                              style: Theme.of(context).textTheme.subtitle2,
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
                        "Description: ${x.description!}"),
                  ),
                  Divider(
                    color: Colors.white,
                    thickness: 2,
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  Text(
                      style: Theme.of(context).textTheme.subtitle1,
                      "Date of rating: ${formatter.format(x.date!).toString()}"),
                ]),
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }

  List<Widget> _buildRecommendedProdcuts() {
    // build recommended products slider
    if (_recommendedProducts.isEmpty) {
      return [
        Text(style: Theme.of(context).textTheme.headline6, "Loading.....")
      ];
    }

    List<Widget> list = _recommendedProducts
        .map((e) => Container(
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
                            "${ProductDetailsScreen.routeName}/${e.productId}");
                      },
                      child: Container(
                          margin: EdgeInsets.only(top: 8),
                          height: 250,
                          child: imageFromBase64String(e.picture!)),
                    ),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Text(
                              style: Theme.of(context).textTheme.subtitle1,
                              e.name ?? ""),
                          Text(
                              style: Theme.of(context).textTheme.subtitle1,
                              formatNumber(e.price)+" "+ e.productType!.currency!.abbreviation!),
                        ],
                      ),
                      IconButton(
                          onPressed: () {
                            _cartProvider?.addToCart(e);
                          },
                          icon: Icon(
                              color: Colors.white, Icons.shopping_bag_rounded)),
                    ],
                  )
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
