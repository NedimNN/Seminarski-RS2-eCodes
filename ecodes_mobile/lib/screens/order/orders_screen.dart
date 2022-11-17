import 'package:ecodes_mobile/providers/order_provider.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/order.dart';
import '../../utils/util.dart';
import 'order_items_screen.dart';

class OrdersScreen extends StatefulWidget {
  static const String routeName = "/orders";
  OrdersScreen({Key? key}) : super(key: key);

  @override
  State<OrdersScreen> createState() => _OrdersScreenState();
}

class _OrdersScreenState extends State<OrdersScreen> {
  OrderProvider? _orderProvider = null;
  List<Order> data = [];
  final DateFormat formatter = DateFormat('yyyy-MM-dd');

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _orderProvider = context.read<OrderProvider>();
    loadData();
  }

  Future loadData() async {
    var searchRequest = {
      'buyerName': Authorization.username,
      'includeItems': true
    };
    var tmpdata = await _orderProvider?.get(searchRequest);
    setState(() {
      data = tmpdata!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
      selectedIndex: 3,
      child: ListView(
        shrinkWrap: true,
        scrollDirection: Axis.vertical,
        children: _buildOrdersGridView(),
      ),
    );
  }

  List<Widget> _buildOrdersGridView() {
    if (data.length == 0) {
      return [
        Container(
          padding: EdgeInsets.only(left: 25),
          child:
              Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
        )
      ];
    }
    List<Widget> list = data
        .map((x) => Container(
              height: 120,
              margin: EdgeInsets.only(left: 5, right: 5, top: 15),
              decoration: BoxDecoration(
                  border: Border.all(
                      color: Color.fromARGB(255, 249, 219, 128), width: 3),
                  borderRadius: BorderRadius.circular(10)),
              child: InkWell(
                child: GridTile(
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Container(
                      padding: EdgeInsets.all(5),
                      child: ClipRRect(
                          borderRadius: BorderRadius.circular(5),
                          child: SizedBox(
                            height: 135,
                            width: 100, // Image radius
                            child: GridView(
                              gridDelegate:
                                  SliverGridDelegateWithFixedCrossAxisCount(
                                      crossAxisCount: _buildImageList(x).length,
                                      childAspectRatio:
                                          1 / _buildImageList(x).length),
                              children: _buildImageList(x),
                              physics: NeverScrollableScrollPhysics(),
                            ),
                          )),
                    ),
                    Container(
                      padding: EdgeInsets.only(top:15,left: 5),
                      child: Column(
                        children: [
                          Text(
                              style: Theme.of(context).textTheme.bodyText2,
                              "Order number: ${x.orderNumber!}"),
                          Text(
                              style: Theme.of(context).textTheme.subtitle2,
                              "Date : ${formatter.format(DateTime.parse(x.date!))}"),
                          Text(
                              style: Theme.of(context).textTheme.subtitle2,
                              "Total price : ${x.price}")
                        ],
                      ),
                    ),
                    Container(
                      padding: EdgeInsets.only(left: 25),
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Text(style: Theme.of(context).textTheme.subtitle2,"Status:"),
                          _buildStatus(x.status!),
                        ],
                      ),
                    )
                  ],
                )),
                onTap: () {
                  Navigator.pushNamed(context,
                      "${OrderItemsScreen.routeName}/${x.orderId}"); //<- Go to OrderItems of this order
                },
              ),
            ))
        .cast<Widget>()
        .toList();
    return list;
  }
  Widget _buildStatus(bool status){
    if(status == true){
      return Icon(Icons.check_circle_outline,color: Colors.green,);
    }
    else{
      return Icon(Icons.dnd_forwardslash_outlined,color: Colors.red,);
    }
  }
  List<Widget> _buildImageList(Order order) {
    List<Widget> list = [];
    for (var orderitem in order.orderItems!) {
      list.add(imageFromBase64String(orderitem.product!.picture!));
    }
    return list;
  }
}
