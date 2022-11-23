import 'package:ecodes_mobile/model/cart.dart';
import 'package:ecodes_mobile/screens/products/product_details_screen.dart';
import 'package:ecodes_mobile/utils/util.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../model/product.dart';
import '../../providers/cart_provider.dart';
import '../../providers/product_provider.dart';

class ProductsSearchScreen extends StatefulWidget {
  static const String routeName = "/products_search";
  const ProductsSearchScreen({Key? key}) : super(key: key);

  @override
  State<ProductsSearchScreen> createState() => _ProductsSearchScreenState();
}

class _ProductsSearchScreenState extends State<ProductsSearchScreen> {
  ProductProvider? _productProvider = null;
  CartProvider? _cartProvider = null;
  List<Product> data = [];
  TextEditingController _searchController = new TextEditingController();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    _cartProvider = context.read<CartProvider>();
    loadData();
  }

  Future loadData() async {
    var productSearch = {'StateMachine': 'active', 'IncludeType': true};
    var tmpdata = await _productProvider?.get(productSearch);
    setState(() {
      data = tmpdata!;
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
              child: Column(
            children: [
              _buildProductSearchAndSort(),
              if (_buildProductsCard("PlayStation").isEmpty == false) ...[
                _buidHeader("PlayStation"),
                SizedBox(
                  height: 500,
                  child: GridView(
                    scrollDirection: Axis.horizontal,
                    padding: const EdgeInsets.all(10),
                    gridDelegate:
                        const SliverGridDelegateWithFixedCrossAxisCount(
                            crossAxisCount: 1,
                            childAspectRatio: 3 / 2,
                            crossAxisSpacing: 20,
                            mainAxisSpacing: 20),
                    children: _buildProductsCard("PlayStation"),
                  ),
                ),
                SizedBox(
                    width: MediaQuery.of(context).size.width - 55,
                    child: Divider(
                      thickness: 3,
                      color: Colors.blue,
                    )),
              ],
              if (_buildProductsCard("Xbox").isEmpty == false) ...[
                _buidHeader("Xbox"),
                SizedBox(
                  height: 500,
                  child: GridView(
                    scrollDirection: Axis.horizontal,
                    padding: const EdgeInsets.all(10),
                    gridDelegate:
                        const SliverGridDelegateWithFixedCrossAxisCount(
                            crossAxisCount: 1,
                            childAspectRatio: 3 / 2,
                            crossAxisSpacing: 20,
                            mainAxisSpacing: 20),
                    children: _buildProductsCard("Xbox"),
                  ),
                ),
                SizedBox(
                    width: MediaQuery.of(context).size.width - 55,
                    child: Divider(
                      thickness: 3,
                      color: Colors.blue,
                    )),
              ],
              if (_buildProductsCard("Netflix").isEmpty == false) ...[
                _buidHeader("Netflix"),
                SizedBox(
                  height: 500,
                  child: GridView(
                    scrollDirection: Axis.horizontal,
                    padding: const EdgeInsets.all(10),
                    gridDelegate:
                        const SliverGridDelegateWithFixedCrossAxisCount(
                            crossAxisCount: 1,
                            childAspectRatio: 3 / 2,
                            crossAxisSpacing: 20,
                            mainAxisSpacing: 20),
                    children: _buildProductsCard("Netflix"),
                  ),
                ),
                SizedBox(
                    width: MediaQuery.of(context).size.width - 55,
                    child: Divider(
                      thickness: 3,
                      color: Colors.blue,
                    )),
              ]
            ],
          )),
        ],
      ),
    );
  }

  Widget _buidHeader(String productName) {
    return Container(
      padding: EdgeInsets.only(left: 15, right: 15, top: 5, bottom: 5),
      decoration: BoxDecoration(
        color: Colors.blue,
        borderRadius: BorderRadius.circular(35),
      ),
      child: Text(
        productName,
        style: Theme.of(context).textTheme.headline3,
      ),
    );
  }

  Widget _buildProductSearchAndSort() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: EdgeInsets.symmetric(horizontal: 10, vertical: 20),
            child: TextField(
              style: Theme.of(context).textTheme.subtitle2,
              controller: _searchController,
              onSubmitted: (value) async {
                var tempdata = await _productProvider?.get({
                  'name': value,
                  'StateMachine': 'active',
                  'IncludeType': true
                });
                setState(() {
                  data = tempdata!;
                });
              },
              decoration: InputDecoration(
                  hintText: "Search",
                  prefixIcon: Icon(
                    Icons.search,
                    color: Colors.black,
                  ),
                  enabledBorder: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide:
                          const BorderSide(color: Colors.black, width: 3)),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide: const BorderSide(color: Colors.black)),
                  filled: true,
                  fillColor: Color.fromARGB(192, 226, 226, 226)),
            ),
          ),
        ),
        Container(
          padding: EdgeInsets.symmetric(horizontal: 10, vertical: 20),
          child: Container(
            decoration: BoxDecoration(
              color: Color.fromARGB(188, 255, 255, 255),
              borderRadius: BorderRadius.circular(15)
            ),
            child: IconButton(
              icon: Icon(Icons.filter_list,color: Colors.black,),
              onPressed: () async {
                var tempdata = await _productProvider?.get({
                  'name': _searchController.text,
                  'StateMachine': 'active',
                  'IncludeType': true
                });
                setState(() {
                  data = tempdata!;
                });
              },
            ),
          ),
        ),
      ],
    );
  }

  List<Widget> _buildProductsCard(String sortName) {
    if (data.length == 0) {
      return [
        Container(
          padding: EdgeInsets.only(left: 25),
          child:
              Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
        )
      ];
    }

    List<Product> sortedData = [];
    for (var product in data) {
      if (product.name!.contains(sortName)) {
        sortedData.add(product);
      }
    }
    if (sortedData.isEmpty) {
      return [];
    }
    List<Widget> list = sortedData
        .map((x) => Container(
            margin: EdgeInsets.all(16),
            child: GridTile(
              key: ValueKey(x),
              child: InkWell(
                  onTap: () {
                    Navigator.pushNamed(context,
                        "${ProductDetailsScreen.routeName}/${x.productId}");
                  },
                  child: ClipRRect(
                      borderRadius: BorderRadius.circular(15),
                      child: SizedBox.fromSize(
                        size: Size.fromRadius(48), // Image radius
                        child: imageFromBase64String(x.picture!),
                      ))),
              footer: GridTileBar(
                backgroundColor: Colors.black54,
                title: Text(
                  x.name!,
                  style: const TextStyle(
                      fontSize: 18, fontWeight: FontWeight.bold),
                ),
                subtitle: Text(formatNumber(x.price)),
                trailing: IconButton(
                    onPressed: () {
                      _cartProvider?.addToCart(x);
                    },
                    icon:
                        Icon(color: Colors.white, Icons.shopping_bag_rounded)),
              ),
            )))
        .cast<Widget>()
        .toList();
    return list;
  }
}
