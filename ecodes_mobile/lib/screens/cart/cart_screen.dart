import '../../model/currency.dart';
import '../../model/loyaltyPoints.dart';
import '../../model/notification.dart';
import '../../model/payment.dart';
import '../../model/product.dart';
import '../../providers/currency_provider.dart';
import '../../providers/loyatlyPoints_provider.dart';
import '../../providers/payment_provider.dart';
import '../../providers/product_provider.dart';
import '../../screens/order/order_items_screen.dart';
import '../../widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_braintree/flutter_braintree.dart';
import 'package:provider/provider.dart';

import '../../model/cart.dart';
import '../../model/order.dart';
import '../../providers/cart_provider.dart';
import '../../providers/notification_provider.dart';
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
  late NotificationProvider _notificationProvider;
  LoyaltyPoints _loyaltyPoints = new LoyaltyPoints();
  Currency _currency = new Currency();
  var isLoading = false;
  var isNotified = false;
  var isCorrect = true;
  TextEditingController _loyaltyPointsController = new TextEditingController();

  @override
  void initState() {
    //TODO: implement initState
    super.initState();
    _currencyProvider = context.read<CurrencyProvider>();
    _loyaltyProvider = context.read<LoyaltyPointsProvider>();
    _paymentProvider = context.read<PaymentProvider>();
    _productProvider = context.read<ProductProvider>();
    _notificationProvider = context.read<NotificationProvider>();
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
                  "Total: ${_cartProvider.cart.PriceToPay.toStringAsFixed(2)} USD"),
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
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            SizedBox(
              height: 75,
              width: 75,
              child: Container(child: Icon(size: 55, Icons.loyalty_rounded)),
            ),
            Expanded(
              child: Center(
                child: Text(
                    style: Theme.of(context).textTheme.bodyText2,
                    "Total points earned: ${_loyaltyPoints.balance}"),
              ),
            )
          ],
        ),
        SizedBox(
          width: 170,
          child: TextField(
            controller: _loyaltyPointsController,
            keyboardType: TextInputType.numberWithOptions(decimal: true),
            style: TextStyle(
              color: Colors.black,
              fontWeight: FontWeight.bold,
              fontSize: 25,
            ),
            textAlign: TextAlign.center,
            decoration: InputDecoration(
                hintStyle: TextStyle(color: Colors.black),
                label: Center(child: Text("Loyalty Points")),
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
      isCorrect = false;
      return 'Can\'t use more than 75 points';
    } else if (_loyaltyPoints.balance != null &&
        _loyaltyPoints.balance! < double.parse(text)) {
      isCorrect = false;
      return 'You don\'t have enough points';
    }
    isCorrect = true;
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
          "Price: ${item.product.price.toString()} ${item.product.productType!.currency!.abbreviation}\nFrom Seller: ${item.product.seller!.name}"),
      trailing: Container(
        margin: EdgeInsets.only(top: 5),
        child: InkWell(
          onTap: () {
            _cartProvider.removeFromCart(item.product);
          },
          child: Icon(
              size: 35, color: Colors.redAccent, Icons.delete_forever_rounded),
        ),
      ),
    );
  }

  void _buildLoading() {
    if (isLoading == true) {
      showDialog(
          context: context,
          builder: (BuildContext build) => AlertDialog(
                title: Text("Loading.."),
                content: CircularProgressIndicator(),
              ));
    } else {
      Navigator.pop(context);
    }
  }

  Future<dynamic> _buildDialog(String title, String content) {
    return showDialog(
        barrierDismissible: false,
        context: context,
        builder: (BuildContext context) => AlertDialog(
              title: Text(
                title,
                style: Theme.of(context).textTheme.headline4,
              ),
              content: Text(
                content,
                style: TextStyle(
                    color: Color.fromARGB(255, 107, 107, 107), fontSize: 18),
              ),
              actions: [
                TextButton(
                    onPressed: () => Navigator.pop(context), child: Text("Ok")),
              ],
            ));
  }

  Future<bool> _createNotification(Order insertedOrder) async {
    if (isNotified == true) {
      return true;
    }
    if (isNotified == false) {
      Notif? _newNotif = new Notif();
      _newNotif.buyerId = Authorization.buyerId;
      _newNotif.notificationDateTime = DateTime.now();
      _newNotif.notificationDesc =
          "Successfull transaction for order number: ${insertedOrder.orderNumber}";
      var insertedNotif = await _notificationProvider.insert(_newNotif);
      return true;
    }
    return false;
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
        if (_cartProvider.cart.items.isEmpty == true) {
          return await _buildDialog(
              "Important Information !", "Your cart is empty !");
        } else if (isCorrect == false) {
          return await await _buildDialog("Important Information !",
              "There is an error with your loyalty points !");
        }
        // Need to implement payment system here onPressed (checkout button)
        var tokenKey = 'sandbox_v2bd8x6j_hcbc2pqgtd5gzdn7';
        var request = BraintreePayPalRequest();
        Payment payment = new Payment();
        payment.successful = false;
        List<Product> clearProducts = [];
        List<Payment> payments = [];
        int paymentsFailed = 0;
        if (_cartProvider.cart.items.length > 1) {
          await showDialog(
              barrierDismissible: false,
              context: context,
              builder: (BuildContext context) => AlertDialog(
                    title: Text(
                      "Important Information !",
                      style: Theme.of(context).textTheme.headline4,
                    ),
                    content: Text(
                      "Your cart has more then 1 item which means you're going to have to make multiple transactions for security reasons. Thank you for your understanding!\nNote: You\'re going to be redirected to Paypal to finish payment!",
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
          await showDialog(
              barrierDismissible: false,
              context: context,
              builder: (BuildContext context) => AlertDialog(
                    title: Text(
                      "Important Information !",
                      style: Theme.of(context).textTheme.headline4,
                    ),
                    content: Text(
                      "You\'re going to be redirected to Paypal to finish your payment!\nNote: If you want to canel your payment you can do so on PayPal!",
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
        }
        List<Map> items = [];

        if (block == false) {
          for (var item in _cartProvider.cart.items) {
            var itemprice = item.product.price;
            if (item.product.productType!.currency!.abbreviation != "USD") {
              itemprice = await exchangeToUSD(item.product.price!,
                  item.product.productType!.currency!.abbreviation!);
            }
            if (item.product.price! > 0.00) {
              request = BraintreePayPalRequest(
                amount: (itemprice).toString(),
                currencyCode: "USD",
                displayName: "eCodes",
              );
            } else {
              return await _buildDialog("Something went wrong!",
                  "There was an error with the conversion from EUR to USD, please try again later!");
            }
            var result = await Braintree.requestPaypalNonce(tokenKey, request);
            if (result != null) {
              // Call the server-side transaction here
              payment.amount = item.product.price!;
              payment.buyerId = Authorization.buyerId;
              payment.paymentMethodNonce = result.nonce;
              payment.productId = item.product.productId;
              payment.successful = false;
              Payment? transaction = null;
              // Check if buyer used loyaltypoints and then add them to payment variable
              payment.usedLoyaltyPoints =
                  double.parse(_loyaltyPointsController.text);

              setState(() {
                isLoading = true;
              });
              _buildLoading();
              try {
                transaction = await _paymentProvider.beginTransaction(payment);
              } catch (e) {
                await _buildDialog("Error", e.toString());
              }
              setState(() {
                isLoading = false;
              });
              _buildLoading();
              if (transaction?.successful == true) {
                payments.add(transaction!);
                await showDialog(
                    barrierDismissible: false,
                    context: context,
                    builder: (BuildContext context) => AlertDialog(
                          title: Text(
                            "Payment successful!",
                            style: Theme.of(context).textTheme.headline4,
                          ),
                          content: Text(
                            "Successfully paid for product ${item.product.name}\nPrice: ${transaction?.amount} ${item.product.productType!.currency!.abbreviation} ",
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
                var hiddenProduct =
                    await _productProvider.hideProduct(item.product.productId!);
                clearProducts.add(item.product);
                items.add({
                  "productId": item.product.productId,
                });
              }
            } else {
              paymentsFailed++;
              await showDialog(
                  barrierDismissible: false,
                  context: context,
                  builder: (BuildContext context) => AlertDialog(
                        title: Text(
                          "Important Information !",
                          style: Theme.of(context).textTheme.headline4,
                        ),
                        content: Text(
                          "Payment was cancelled for product ${item.product.name}!",
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
            }
          }
        }
        Map order = {"items": items, "status": true, "canceled": false};

        if (_cartProvider.cart.items.length >= payments.length &&
            _cartProvider.cart.items.length > paymentsFailed &&
            payments.isNotEmpty) {
          var reutrnedOrder = await _orderProvider.insert(order);
          var insertedOrder =
              await _orderProvider.getById(reutrnedOrder!.orderId!);
          var output = await _paymentProvider.saveTransaction(
              insertedOrder.orderId!, payment.usedLoyaltyPoints!);
          if (_loyaltyPointsController.text == 0.00.toString()) {
            var percentage = payment.usedLoyaltyPoints! / 100;
            var pricetodisplay = _cartProvider.cart.PriceToPay -
                (_cartProvider.cart.PriceToPay * percentage);
            output?.price = pricetodisplay.toString();
          }

          await showDialog(
              barrierDismissible: false,
              context: context,
              builder: (BuildContext context) => AlertDialog(
                    title: Text(
                      "Transaction completed successfully",
                      style: Theme.of(context).textTheme.headline4,
                    ),
                    content: Text(
                      "Successfully paid for order number: ${insertedOrder.orderNumber}, with total price of ${output?.price} ${_currency.abbreviation} . ",
                      style: Theme.of(context).textTheme.subtitle2,
                    ),
                    actions: [
                      TextButton(
                          onPressed: () {
                            Navigator.pop(context);
                          },
                          child: Text("Ok")),
                      TextButton(
                          onPressed: () async {
                            isNotified =
                                await _createNotification(insertedOrder);
                            for (var element in clearProducts) {
                              _cartProvider.removeFromCart(element);
                            }
                            clearProducts.clear();
                            if (isNotified == true) {
                              Navigator.pushNamed(context,
                                  "${OrderItemsScreen.routeName}/${insertedOrder.orderId}");
                            }
                          },
                          child: Text("Order Details")),
                    ],
                  ));
          isNotified = await _createNotification(insertedOrder);
          for (var element in clearProducts) {
            _cartProvider.removeFromCart(element);
          }
          clearProducts.clear();
          _loyaltyPoints.balance =
              _loyaltyPoints.balance! - payment.usedLoyaltyPoints!;
        } else if (_cartProvider.cart.items.length == paymentsFailed) {
          await _buildDialog("Important Information !",
              "Payment was canceled for all products, you can try again later!");
        } else {
          await _buildDialog("Payment failed!",
              "Something went wrong with the payment system. Please, try again later!");
          try {
            Notif? _newNotif = new Notif();
            _newNotif.buyerId = Authorization.buyerId;
            _newNotif.notificationDateTime = DateTime.now();
            _newNotif.notificationDesc =
                "Transaction failed please try again later";
            var insertedNotif = await _notificationProvider.insert(_newNotif);
          } catch (e) {
            await _buildDialog("Error", e.toString());
          }
        }
      },
    );
  }
}
