import 'package:ecodes_mobile/providers/cart_provider.dart';
import 'package:ecodes_mobile/screens/products/product_list_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../screens/cart/cart_screen.dart';

class eCodesDrawer extends StatelessWidget {
  eCodesDrawer({Key? key}) : super(key: key);
  CartProvider? _cartProvider;

  @override
  Widget build(BuildContext context) {
    _cartProvider = context.watch<CartProvider>();
    return Drawer(
      child: ListView(
        children: [
          ListTile(
            title: Text("Home"),
            onTap: () {
              Navigator.popAndPushNamed(context, ProductListScreen.routeName);
            },
          ),
          ListTile(
            title: Text("Cart ${_cartProvider?.cart.items.length}"),
            onTap: () {
              Navigator.popAndPushNamed(context, CartScreen.routeName);
            },
          )
        ],
      ),
    );
  }
}
