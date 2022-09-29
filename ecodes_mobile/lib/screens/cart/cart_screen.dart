import 'package:ecodes_mobile/model/currency.dart';
import 'package:ecodes_mobile/model/wallet.dart';
import 'package:ecodes_mobile/providers/currency_provider.dart';
import 'package:ecodes_mobile/providers/wallet_provider.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../model/cart.dart';
import '../../providers/cart_provider.dart';
import '../../providers/order_provider.dart';
import '../../utils/util.dart';
import '../products/product_list_screen.dart';

class CartScreen extends StatefulWidget {
  static const routeName = "/cart";

  const CartScreen({Key? key}) : super(key: key);

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {
  late CartProvider _cartProvider;
  late OrderProvider _orderProvider;
  late CurrencyProvider _currencyProvider;
  late WalletProvider _walletProvider;
  Wallet _wallet = new Wallet();
  Currency _currency = new Currency();

  @override
  void initState() {
    //TODO: implement initState
    super.initState();
    _currencyProvider = context.read<CurrencyProvider>();
    _walletProvider = context.read<WalletProvider>();
    loadData();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _cartProvider = context.watch<CartProvider>();
    _orderProvider = context.read<OrderProvider>();
  }

  void loadData() async {
    var searchRequest = {'buyerId': Authorization.buyerId};
    var wallet = await _walletProvider.get(searchRequest);
    var currency = await _currencyProvider.getById(wallet.first.currencyId!);
    setState(() {
      _wallet = wallet.first;
      _currency = currency;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
      selectedIndex: 2,
      child: Column(
        children: [
          Divider(
            color: Colors.grey,
          ),
          _buildWalletHeader(),
          Divider(
            color: Colors.grey,
          ),
          Expanded(child: _buildProductCardList()),
          Container(
              width: MediaQuery.of(context).size.width,
              child: _buildBuyButton()),
        ],
      ),
    );
  }

  Widget _buildWalletHeader() {
    if (_wallet == null) {
      return Container(
        padding: EdgeInsets.only(left: 25),
        child: Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
      );
    }

    return Container(
      width: MediaQuery.of(context).size.width,
      child: Column(children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            SizedBox(
              height: 75,
              width: 75,
              child: Container(
                  child: Icon(size: 55, Icons.account_balance_wallet_outlined)),
            ),
            SizedBox(
              height: 75,
              width: 250,
              child: Center(
                child: Text(
                    style: Theme.of(context).textTheme.bodyText2,
                    "Total balance: ${_wallet.balance} ${_currency.abbreviation}"),
              ),
            )
          ],
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            SizedBox(
              width: 125,
              child: Column(
                children: [
                  InkWell(
                    onTap: () {
                      // Take user to add funds screen
                    },
                    child: Icon(size: 55, Icons.add_circle_outline),
                  ),
                  Center(child: Text("Add funds")),
                ],
              ),
            ),
            SizedBox(
              width: 55,
            ),
            SizedBox(
              width: 175,
              child: Column(
                children: [
                  InkWell(
                    onTap: () {
                      // Take user to change currency screen
                    },
                    child: Icon(size: 55, Icons.currency_exchange_rounded),
                  ),
                  Center(
                    child: Text("Change currency"),
                  ),
                ],
              ),
            )
          ],
        )
      ]),
    );
  }

  Widget _buildProductCardList() {
    return SafeArea(
      child: Card(
        child: ListView.builder(
          itemCount: _cartProvider.cart.items.length,
          itemBuilder: (context, index) {
            return _buildProductCard(_cartProvider.cart.items[index]);
          },
        ),
      ),
    );
  }

  Widget _buildProductCard(CartItem item) {
    return ListTile(
      tileColor: Color.fromARGB(255, 99, 123, 255),
      shape: RoundedRectangleBorder(
        side: BorderSide(color: Colors.white, width: 3),
        borderRadius: BorderRadius.circular(15),
      ),
      contentPadding: EdgeInsets.all(5),
      visualDensity: VisualDensity(vertical: 4),
      leading: imageFromBase64String(item.product.picture!),
      title: Text(
          style: TextStyle(
              color: Colors.white, fontWeight: FontWeight.bold, fontSize: 20),
          item.product.name ?? ""),
      subtitle: Text(
          style: TextStyle(
              color: Colors.white, fontWeight: FontWeight.bold, fontSize: 15),
          "Price: ${item.product.price.toString()}   Quantity: ${item.count.toString()}"),
      trailing: Row(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Container(
            margin: EdgeInsets.only(top: 5),
            child: InkWell(
                onTap: () {
                  _cartProvider.addToCart(item.product);
                },
                child: Container(child: Icon(size: 35, Icons.add))),
          ),
          Container(
            margin: EdgeInsets.only(top: 5),
            child: InkWell(
              onTap: () {
                _cartProvider.removeFromCart(item.product);
              },
              child: Icon(
                  size: 35,
                  color: Colors.redAccent,
                  Icons.delete_forever_rounded),
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildBuyButton() {
    return TextButton(
      style: TextButton.styleFrom(
          backgroundColor: Color.fromARGB(195, 3, 125, 182)),
      child: Text(
          style: TextStyle(
            color: Colors.white,
            fontWeight: FontWeight.bold,
            fontSize: 25,
          ),
          "Buy"),
      onPressed: () async {
        List<Map> items = [];
        _cartProvider.cart.items.forEach((item) {
          items.add({
            "productId": item.product.productId,
            "quantity": item.count,
          });
        });
        Map order = {
          "items": items,
        };

        await _orderProvider.insert(order);

        _cartProvider.cart.items.clear();

        Navigator.popAndPushNamed(context, ProductListScreen.routeName);

        setState(() {});
      },
    );
  }
}
