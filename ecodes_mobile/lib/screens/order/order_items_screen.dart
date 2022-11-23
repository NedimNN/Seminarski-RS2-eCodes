import '../../model/order.dart';
import '../../model/rating.dart';
import '../../screens/rating/rating_screen.dart';
import '../../utils/util.dart';
import '../../widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/orderItem.dart';
import '../../providers/orderItems_provider.dart';
import '../../providers/order_provider.dart';
import '../../providers/rating_provider.dart';

class OrderItemsScreen extends StatefulWidget {
  static const String routeName = "/orderitems";

  String id;
  OrderItemsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<OrderItemsScreen> createState() => _OrderItemsScreenState();
}

class _OrderItemsScreenState extends State<OrderItemsScreen> {
  OrderProvider? _orderProvider = null;
  RatingProvider? _ratingProvider = null;

  final DateFormat formatter = DateFormat('yyyy-MM-dd');

  List<OrderItem> data = [];
  Order _orderData = new Order();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _orderProvider = context.read<OrderProvider>();
    _ratingProvider = context.read<RatingProvider>();

    loadData(this.widget.id);
  }

  Future loadData(String id) async {
    var identity = int.parse(id);
    var tmpOrder = await _orderProvider?.getById(identity);
    setState(() {
      _orderData = tmpOrder!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
        selectedIndex: 3,
        child: Column(children: [
          _buildHeader1(),
          SizedBox(
              width: MediaQuery.of(context).size.width - 55,
              child: Divider(
                thickness: 3,
                color: Colors.blueGrey,
              )),
          _buildHeader2(),
          Expanded(
              child: ListView(
            scrollDirection: Axis.vertical,
            padding: const EdgeInsets.all(10),
            children: _buildOrderItemsListView(),
          )),
          _buildFooter()
        ]));
  }

  Widget _buildHeader1() {
    if (_orderData.orderItems == null) {
      return Container(
        padding: EdgeInsets.only(left: 25),
        child: Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
      );
    }
    return SizedBox(
        height: 35,
        child: Center(
          child: Text(
              style: Theme.of(context).textTheme.headline6,
              "Order Number: ${_orderData.orderNumber!}"),
        ));
  }

  Widget _buildHeader2() {
    if (_orderData.orderItems == null) {
      return Container(
        padding: EdgeInsets.only(left: 25),
        child: Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
      );
    }
    return SizedBox(
        height: 35,
        child: Center(
          child: Text(
              style: Theme.of(context).textTheme.headline6,
              "Date : ${formatter.format(DateTime.parse(_orderData.date!))}"),
        ));
  }

  Widget _buildFooter() {
    if (_orderData.orderItems == null) {
      return Container(
        padding: EdgeInsets.only(left: 25),
        child: Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
      );
    }
    return Container(
      margin: EdgeInsets.only(left: 15, right: 15, bottom: 5, top: 5),
      decoration: BoxDecoration(
          color: Color.fromARGB(195, 31, 173, 238),
          borderRadius: BorderRadius.all(Radius.circular(25))),
      child: SizedBox(
          height: 35,
          child: Center(
            child: Text(
                style: Theme.of(context).textTheme.bodyText2,
                "Total: ${_orderData.price!}"),
          )),
    );
  }

  List<Widget> _buildOrderItemsListView() {
    if (_orderData.orderItems == null) {
      return [
        Container(
          padding: EdgeInsets.only(left: 25),
          child:
              Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
        )
      ];
    }

    List<Widget> list = _orderData.orderItems!
        .map((x) => Container(
            margin: EdgeInsets.only(top: 15, bottom: 15),
            decoration: BoxDecoration(
                border: Border(
                  top: BorderSide(),
                  right: BorderSide(),
                  bottom: BorderSide(),
                  left: BorderSide(),
                ),
                borderRadius: BorderRadius.all(Radius.circular(15))),
            child: ListTile(
              leading: ClipRRect(
                  borderRadius: BorderRadius.circular(15),
                  child: SizedBox(
                      child: imageFromBase64String(x.product!.picture!))),
              visualDensity: VisualDensity(vertical: 4),
              title: Text(
                  style: Theme.of(context).textTheme.bodyText2,
                  x.product!.name!),
              isThreeLine: true,
              subtitle: Text(
                  style: TextStyle(color: Colors.black, fontSize: 15),
                  "${x.product!.productTypeName}\nSeller: ${x.product!.seller!.name}"),
              trailing: SizedBox(
                width: 130,
                child: Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Container(
                      child: InkWell(
                        onTap: () async {
                          bool hidden = true;
                          TextEditingController keyController =
                              new TextEditingController();
                          keyController.text = x.product!.giftCardKey!;
                          showDialog(
                              context: context,
                              builder: (context) {
                                return StatefulBuilder(
                                    builder: (context, setState) {
                                  return AlertDialog(
                                    title: Center(
                                      child: Text(
                                        "Gift Card key",
                                        style:
                                            Theme.of(context).textTheme.headline4,
                                      ),
                                    ),
                                    content: Container(
                                      child: TextField(
                                        controller: keyController,
                                        readOnly: true,
                                        obscureText: hidden,
                                        style: Theme.of(context)
                                            .textTheme
                                            .bodyText2,
                                            textAlign: TextAlign.center,
                                      ),
                                    ),
                                    actions: [
                                      TextButton(
                                        onPressed: () {
                                          setState(() {
                                            hidden
                                                ? hidden = false
                                                : hidden = true;
                                          });
                                        },
                                        child: Text(
                                          "Show Key",
                                          style: Theme.of(context)
                                              .textTheme
                                              .subtitle2,
                                        ),
                                        style: ButtonStyle(),
                                      ),
                                      TextButton(
                                          onPressed: () {
                                            Navigator.pop(context);
                                          },
                                          child: Text(
                                            "Ok",
                                            style: Theme.of(context)
                                                .textTheme
                                                .subtitle2,
                                          )),
                                    ],
                                  );
                                });
                              });
                        },
                        child: RotatedBox(
                            quarterTurns: 1,
                            child: Icon(
                              Icons.key_rounded,
                              size: 35,
                              color: Color.fromARGB(195, 31, 173, 238),
                            )),
                      ),
                    ),
                    Container(
                      margin: EdgeInsets.only(left: 15),
                      child: InkWell(
                          onTap: () async {
                            var ratings =
                                await _ratingProvider?.get() as List<Rating>;
                            Rating? storedRating = null;
                            for (var item in ratings) {
                              if (item.buyerId == Authorization.buyerId &&
                                  item.productId == x.product!.productId) {
                                storedRating = item;
                              }
                            }
                            if (storedRating == null) {
                              showDialog(
                                  context: context,
                                  builder: (BuildContext context) {
                                    return Dialog(
                                      shape: RoundedRectangleBorder(
                                          borderRadius:
                                              BorderRadius.circular(20.0)),
                                      child: RatingScreen(
                                          Authorization.buyerId.toString(),
                                          x.product!.productId.toString(),x.product!.seller!.sellerId.toString()),
                                    );
                                  });
                            } else {
                              showDialog(
                                  context: context,
                                  builder: (BuildContext context) =>
                                      AlertDialog(
                                        title: Text(
                                            style: Theme.of(context)
                                                .textTheme
                                                .bodyText2,
                                            "Product was rated"),
                                        content: Container(
                                          height: 150,
                                          child: Column(
                                            children: [
                                              Text(
                                                  style: Theme.of(context)
                                                      .textTheme
                                                      .subtitle2,
                                                  "Can't rate a product twice!"),
                                              SizedBox(
                                                height: 15,
                                              ),
                                              Text(
                                                  style: Theme.of(context)
                                                      .textTheme
                                                      .subtitle2,
                                                  "Date of rating: ${formatter.format(storedRating!.date!)}"),
                                              SizedBox(
                                                height: 15,
                                              ),
                                              Wrap(children: [
                                                Text(
                                                    style: Theme.of(context)
                                                        .textTheme
                                                        .subtitle2,
                                                    "Rating: ${storedRating.mark} "),
                                                Icon(Icons
                                                    .sentiment_satisfied_alt_rounded)
                                              ]),
                                            ],
                                          ),
                                        ),
                                        actions: [
                                          TextButton(
                                              onPressed: () =>
                                                  Navigator.pop(context),
                                              child: Text("Ok"))
                                        ],
                                      ));
                            }
                          },
                          child: Column(
                            children: [
                              Icon(Icons.star_rate_rounded),
                              Container(
                                margin: EdgeInsets.only(top: 5),
                                child: Text(
                                    style: TextStyle(
                                        color: Colors.black, fontSize: 15),
                                    "${x.product!.price} ${x.product!.productType!.currency!.abbreviation}"),
                              )
                            ],
                          )),
                    ),
                  ],
                ),
              ),
            )))
        .cast<Widget>()
        .toList();
    return list;
  }
}
