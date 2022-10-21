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
    var searchRequest = {'buyerName': Authorization.username, 'includeItems': true };
    var tmpdata = await _orderProvider?.get(searchRequest);
    setState(() {
      data = tmpdata!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
      selectedIndex: 3,
      child: SingleChildScrollView(
        child: Column(children: [
          SizedBox(
            height: MediaQuery.of(context).size.height - 125,
            child: ListView(
              scrollDirection: Axis.vertical,
              padding: const EdgeInsets.all(10),
              children: _buildOrdersListView(),
            ),
          )
        ]),
      ),
    );
  }

  List<Widget> _buildOrdersListView() {
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
            child: ListTile(
              leading: ClipRRect(
                  borderRadius: BorderRadius.circular(15),
                  child: SizedBox(
                    height: 125, 
                    width: 100,// Image radius
                    child: GridView(
                      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                          crossAxisCount: 3,
                          childAspectRatio: 1/3),
                      children: _buildImageList(x),
                    ),
                  )),
                  dense: true,
              visualDensity: VisualDensity(vertical: 4),
              title: Text(
                  style: Theme.of(context).textTheme.bodyText2, x.orderNumber!),
              subtitle:
                  Text(style: Theme.of(context).textTheme.subtitle2, formatter.format(DateTime.parse(x.date!))),
              trailing: InkWell(
                  onTap: () {
          Navigator.pushNamed(context,"${OrderItemsScreen.routeName}/${x.orderId}"); //<- Go to OrderItems of this order
                  },
                  child: Icon(Icons.more_horiz)),
            )))
        .cast<Widget>()
        .toList();
    return list;
  }

  List<Widget> _buildImageList(Order order) {
    List<Widget> list = [];
    for (var orderitem in order.orderItems!) {
      list.add(imageFromBase64String(orderitem.product!.picture!));
    }
    return list;
  }
}
