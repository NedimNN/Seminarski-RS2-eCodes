import 'package:ecodes_mobile/screens/cart/cart_screen.dart';
import 'package:ecodes_mobile/screens/products/product_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

import '../screens/products/products_search_screen.dart';
import '../screens/user/user_profile_screen.dart';
import '../utils/util.dart';
import 'ecodes_drawer.dart';

class MasterWidget extends StatefulWidget {
  Widget? child;
  int? selectedIndex = 0;
  MasterWidget({this.child, this.selectedIndex ,Key? key}) : super(key: key);

  @override
  State<MasterWidget> createState() => _MasterWidgetState();
}

class _MasterWidgetState extends State<MasterWidget> {
 


  void _onItemTapped(int index) {
    setState(() {
      widget.selectedIndex = index;
    });
    if (widget.selectedIndex == 0) {
      Navigator.popAndPushNamed(context, ProductListScreen.routeName);
    } else if (widget.selectedIndex == 1) {
      Navigator.popAndPushNamed(context, ProductsSearchScreen.routeName);
    } else if (widget.selectedIndex == 2) {
      Navigator.popAndPushNamed(context, CartScreen.routeName);
    } else if (widget.selectedIndex == 3) {
      Navigator.popAndPushNamed(context,"${UserProfileScreen.routeName}/${Authorization.buyerId}");
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      //drawer: eCodesDrawer(),
      body: SafeArea(child: widget.child!),
      bottomNavigationBar: _buildBottomNavigationBar(widget.selectedIndex!),
    );
  }

  Widget _buildBottomNavigationBar(int selectedIndex) {
    return BottomNavigationBar(
      items: const <BottomNavigationBarItem>[
        BottomNavigationBarItem(
          backgroundColor: Colors.grey,
          icon: Icon(Icons.home_rounded),
          label: 'Home',
        ),
        BottomNavigationBarItem(
          backgroundColor: Colors.grey,
          icon: Icon(Icons.search_rounded),
          label: 'Search',
        ),
        BottomNavigationBarItem(
          backgroundColor: Colors.grey,
          icon: Icon(Icons.shopping_cart_checkout_rounded),
          label: 'Cart',
        ),
        BottomNavigationBarItem(
          backgroundColor: Colors.grey,
          icon: Icon(Icons.account_circle_rounded),
          label: 'Profile',
        )
      ],
      currentIndex: selectedIndex,
      selectedItemColor: Colors.cyanAccent,
      onTap: _onItemTapped,
    );
  }
}