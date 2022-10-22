import 'package:ecodes_mobile/model/currency.dart';
import 'package:ecodes_mobile/model/loyaltyPoints.dart';
import 'package:ecodes_mobile/model/payment.dart';
import 'package:ecodes_mobile/providers/currency_provider.dart';
import 'package:ecodes_mobile/providers/loyatlyPoints_provider.dart';
import 'package:ecodes_mobile/providers/payment_provider.dart';
import 'package:ecodes_mobile/providers/product_provider.dart';
import 'package:ecodes_mobile/screens/order/order_items_screen.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_braintree/flutter_braintree.dart';
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
  late PaymentProvider _paymentProvider;
  late LoyaltyPointsProvider _loyaltyProvider;
  late ProductProvider _productProvider;
  LoyaltyPoints _loyaltyPoints = new LoyaltyPoints();
  Currency _currency = new Currency();
  var isLoading = false;
  TextEditingController _loyaltyPointsController = new TextEditingController();

  @override
  void initState() {
    //TODO: implement initState
    super.initState();
    _currencyProvider = context.read<CurrencyProvider>();
    _loyaltyProvider = context.read<LoyaltyPointsProvider>();
    _paymentProvider = context.read<PaymentProvider>();
    _productProvider = context.read<ProductProvider>();
    _loyaltyPointsController.text = "0.00";
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
    var loyaltyPoints = await _loyaltyProvider.get(searchRequest);
    var tmpCurrency =
        await _currencyProvider.getById(_cartProvider.cart.currencyId!);
    setState(() {
      _loyaltyPoints = loyaltyPoints.first;
      _currency = tmpCurrency;
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
          _buildLoyaltyPointsHeader(),
          Divider(
            color: Colors.grey,
          ),
          Expanded(child: _buildProductCardList()),
          Container(
            padding: EdgeInsets.all(5),
            child: Center(
              child: Text(
                  style: Theme.of(context).textTheme.headline4,
                  "Total: ${_cartProvider.cart.PriceToPay.toStringAsFixed(2)} ${_currency.abbreviation}"),
            ),
          ),
          Divider(
            color: Colors.grey,
          ),
          Container(
              width: MediaQuery.of(context).size.width,
              margin: EdgeInsets.only(left: 10, right: 10),
              child: _buildCheckoutButton()),
        ],
      ),
    );
  }

  Widget _buildLoyaltyPointsHeader() {
    if (_loyaltyPoints == null) {
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
              child: Container(child: Icon(size: 55, Icons.loyalty_rounded)),
            ),
            SizedBox(
              height: 75,
              width: 250,
              child: Center(
                child: Text(
                    style: Theme.of(context).textTheme.bodyText2,
                    "Total points earned: ${_loyaltyPoints.balance} points"),
              ),
            )
          ],
        ),
        SizedBox(
          height: 85,
          width: 175,
          child: TextField(
            controller: _loyaltyPointsController,
            keyboardType: TextInputType.numberWithOptions(decimal: true),
            style: TextStyle(
              color: Colors.black,
              fontWeight: FontWeight.bold,
              fontSize: 25,
            ),
            decoration: InputDecoration(
                border: InputBorder.none,
                hintStyle: TextStyle(color: Colors.black),
                labelText: "Loyaltypoints",
                errorText: _errorText),
            onChanged: (_) => setState(() {}),
          ),
        )
      ]),
    );
  }

  String? get _errorText {
    final text = _loyaltyPointsController.text;
    if (text.isEmpty) {
      return null;
    } else if (double.parse(text) > 75.00) {
      return 'Can\'t use more than 75 points';
    } else if (_loyaltyPoints.balance != null &&
        _loyaltyPoints.balance! < double.parse(text)) {
      return 'You don\'t have enough points';
    }
    return null;
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
          "Price: ${item.product.price.toString()}   Quantity: ${item.count.toString()}\nFrom Seller: ${item.product.seller!.name}"),
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
  void _buildLoading(){
    if(isLoading == true){
    showDialog(context: context, builder: (BuildContext build) => AlertDialog(
      title: Text("Loading.."),
      content: CircularProgressIndicator(),
    ));}
    else{
     Navigator.pop(context);
    }
  }
  Widget _buildCheckoutButton() {
    return TextButton(
      style: TextButton.styleFrom(
          backgroundColor: Color.fromARGB(195, 3, 125, 182)),
      child: Text(
          style: TextStyle(
            color: Colors.white,
            fontWeight: FontWeight.bold,
            fontSize: 25,
          ),
          "Checkout"),
      onPressed: () async {
        bool block = true;
        // Need to implement payment system here onPressed (checkout button)
        var tokenKey = 'sandbox_v2bd8x6j_hcbc2pqgtd5gzdn7';
        var request = BraintreeDropInRequest();
        Payment payment = new Payment();
        payment.successful = false;
        List<Payment> payments = [];
        if (_cartProvider.cart.items.length > 1) {
          await showDialog(
              context: context,
              builder: (BuildContext context) => AlertDialog(
                    title: Text(
                      "Important Information !",
                      style: Theme.of(context).textTheme.headline4,
                    ),
                    content: Text(
                      "Your cart has more then 1 item which means you're going to have to make multiple transactions for security reasons. Thank you for your understanding",
                      style: TextStyle(
                          color: Color.fromARGB(255, 107, 107, 107),
                          fontSize: 18),
                    ),
                    actions: [
                      TextButton(
                          onPressed: () {
                            setState(() {
                              block = false;
                            });
                            Navigator.pop(context);
                          },
                          child: Text("Ok")),
                    ],
                  ));
        } else {
          block = false;
        }
        List<Map> items = [];

        if (block == false) {
          for (var item in _cartProvider.cart.items) {
            request = BraintreeDropInRequest(
              tokenizationKey: tokenKey,
              collectDeviceData: true,
              paypalRequest: BraintreePayPalRequest(
                amount: (item.product.price! * item.count).toString(),
                currencyCode: "USD",
                displayName: "eCodes",
              ),
            );
            var result = await BraintreeDropIn.start(request);
            if (result != null) {
              // Call the server-side transaction here
              payment.amount = (item.product.price! * item.count);
              payment.buyerId = Authorization.buyerId;
              payment.deviceData = result.deviceData;
              payment.paymentMethodNonce = result.paymentMethodNonce.nonce;
              payment.productId = item.product.productId;
              payment.successful = false;
              // Check if buyer used loyaltypoints and then add them to payment variable (preferably with a input box)
              payment.usedLoyaltyPoints =
                  double.parse(_loyaltyPointsController.text);
              setState(() {
                isLoading = true;
              });
              _buildLoading();
              var transaction =
                  await _paymentProvider.beginTransaction(payment);
              setState(() {
                isLoading = false;
              });
              _buildLoading();
              if (transaction?.successful == true) {
                payments.add(transaction!);
                await showDialog(
                    context: context,
                    builder: (BuildContext context) => AlertDialog(
                          title: Text(
                            "Payment successful!",
                            style: Theme.of(context).textTheme.headline4,
                          ),
                          content: Text(
                            "Successfully paid for product ${item.product.name}\nPrice: ${item.product.price} ${item.product.productType!.currency!.abbreviation} ",
                            style: Theme.of(context).textTheme.subtitle2,
                          ),
                          actions: [
                            TextButton(
                                onPressed: () {
                                  setState(() {
                                    payment.successful = true;
                                  });
                                  Navigator.pop(context);
                                },
                                child: Text("Ok")),
                          ],
                        ));
                var hiddenProduct = await _productProvider.hideProduct(item.product.productId!);

                items.add({
                  "productId": item.product.productId,
                  "quantity": item.count,
                });
              }
            }
          }
        }
        Map order = {"items": items, "status": true, "canceled": false};
        int successfullpayments = 0;
        for (var element in payments) {
          if (element.successful == true) {
            successfullpayments++;
          }
        }

        if (payments.length == successfullpayments &&
            _cartProvider.cart.items.length == successfullpayments) {
          //Order insert after transaction
          // List<Map> items = [];
          // _cartProvider.cart.items.forEach((item) {
          //   items.add({
          //     "productId": item.product.productId,
          //     "quantity": item.count,
          //   });
          // });
          // Map order = {"items": items, "status": true, "canceled": false};
          var reutrnedOrder = await _orderProvider.insert(order);
          var insertedOrder = await _orderProvider.getById(reutrnedOrder!.orderId!);
          var output = await _paymentProvider.saveTransaction(
              insertedOrder.orderId!, payment.usedLoyaltyPoints!);
          await showDialog(
                    context: context,
                    builder: (BuildContext context) => AlertDialog(
                          title: Text(
                            "Transaction completed successfully",
                            style: Theme.of(context).textTheme.headline4,
                          ),
                          content: Text(
                            "Successfully paid for order number: ${insertedOrder.orderNumber}, with total price of ${insertedOrder.price} ${_currency.abbreviation} . ",
                            style: Theme.of(context).textTheme.subtitle2,
                          ),
                          actions: [
                            TextButton(
                                onPressed: () {
                                  Navigator.pop(context);
                                },
                                child: Text("Ok")),
                            TextButton(
                                onPressed: () {
                                  Navigator.pushNamed(context,"${OrderItemsScreen.routeName}/${insertedOrder.orderId}");
                                },
                                child: Text("Order Details")),
                          ],
                        ));

          _cartProvider.cart.items.clear();
          _cartProvider.cart.PriceToPay = 0.00;
          _loyaltyPoints.balance = _loyaltyPoints.balance! - payment.usedLoyaltyPoints!;
          setState(() {});
        } else {
          showDialog(
              context: context,
              builder: (BuildContext context) => AlertDialog(
                    title: Text(
                      "Payment failed!",
                      style: Theme.of(context).textTheme.headline4,
                    ),
                    content: Text(
                      "Something went wrong with the payment system. Please, try again later!",
                      style: Theme.of(context).textTheme.subtitle2,
                    ),
                    actions: [
                      TextButton(
                          onPressed: () => Navigator.pop(context),
                          child: Text("Ok"))
                    ],
                  ));
        }
      },
    );
  }
}
