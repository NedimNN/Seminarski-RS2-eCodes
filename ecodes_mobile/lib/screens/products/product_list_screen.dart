import 'package:ecodes_mobile/providers/cart_provider.dart';
import 'package:ecodes_mobile/providers/product_provider.dart';
import 'package:ecodes_mobile/screens/products/product_details_screen.dart';
import 'package:ecodes_mobile/utils/util.dart';
import 'package:ecodes_mobile/widgets/ecodes_drawer.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/product.dart';

class ProductListScreen extends StatefulWidget {
  static const String routeName = "/products";

  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  ProductProvider? _productProvider = null;
  CartProvider? _cartProvider = null;
  List<Product> data = [];
  TextEditingController _searchController = new TextEditingController();
  final items = ['PlayStation', 'Xbox', 'Netflix'];
  String? value;
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
        selectedIndex: 0,
        child: SingleChildScrollView(
          child: Container(
            child: Column(
              children: [
                _buidHeader(),
                Divider(
                  color: Colors.grey,
                  indent: 25,
                  endIndent: 25,
                  thickness: 2,
                ),
                _buildProductSearchAndSort(),
                Container(
                  margin: EdgeInsets.all(16),
                  child: GridView(
                    shrinkWrap: true,
                    scrollDirection: Axis.vertical,
                    physics: ScrollPhysics(),
                    gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2,
                        mainAxisSpacing: 16,
                        crossAxisSpacing: 16),
                    children: _buildProductGrid(),
                  ),
                )
              ],
            ),
          ),
        ));
  }

  Widget _buidHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 10, vertical: 20),
      child: Text(
        "Gift Cards",
        style: Theme.of(context).textTheme.headline6,
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
              style: TextStyle(color: Colors.black),
              controller: _searchController,
              onSubmitted: (value) async {
                var tempdata = await _productProvider?.get({'name': value});
                setState(() {
                  data = tempdata!;
                });
              },
              decoration: InputDecoration(
                  hintText: "Search",
                  prefixIcon: Icon(Icons.search),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide: BorderSide(color: Colors.grey))),
            ),
          ),
        ),
        Container(
          padding: EdgeInsets.symmetric(horizontal: 10, vertical: 20),
          child: Container(
            padding: EdgeInsets.all(3),
            decoration: BoxDecoration(
                border: Border.all(color: Colors.grey),
                borderRadius: BorderRadius.circular(10)),
            child: DropdownButtonHideUnderline(
              child: DropdownButton<String>(
                value: value,
                hint: Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Text("Sort by"),
                ),
                icon: Icon(Icons.arrow_drop_down),
                items: items.map(_buildMenuItem).toList(),
                onChanged: (value) async {
                  var productSearch = {'StateMachine': 'active','platform': value};
                  var tempdata =
                      await _productProvider?.get(productSearch);
                  setState(() {
                    data = tempdata!;
                    this.value = value!;
                  });
                },
              ),
            ),
          ),
        )
      ],
    );
  }

  DropdownMenuItem<String> _buildMenuItem(String item) => DropdownMenuItem(
      value: item,
      child: Text(
        item,
        style: Theme.of(context).textTheme.subtitle2,
      ));

  List<Widget> _buildProductGrid() {
    if (data.length == 0) {
      return [Text("Loading.....")];
    }
    List<Widget> list = data
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
                              style: Theme.of(context).textTheme.subtitle1,
                              x.name ?? ""),
                          Text(
                              style: Theme.of(context).textTheme.subtitle1,
                              formatNumber(x.price)+" "+ x.productType!.currency!.abbreviation!),
                        ],
                      ),
                      IconButton(
                          onPressed: () {
                            _cartProvider?.addToCart(x);
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
