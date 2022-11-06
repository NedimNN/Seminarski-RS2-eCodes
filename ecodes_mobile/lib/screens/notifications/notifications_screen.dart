import 'package:ecodes_mobile/providers/notification_provider.dart';
import 'package:ecodes_mobile/utils/util.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/notification.dart';

class NotificationScreen extends StatefulWidget {
  static const String routeName = "/notifications";
  NotificationScreen({Key? key}) : super(key: key);

  @override
  State<NotificationScreen> createState() => _NotificationScreenState();
}

class _NotificationScreenState extends State<NotificationScreen> {
  NotificationProvider? _notificationProvider = null;
  List<Notif> _notifications = [];
  final DateFormat formatter = DateFormat('yyyy-MM-dd');

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _notificationProvider = context.read<NotificationProvider>();
    loadData();
  }

  void loadData() async {
    var searchObject = {'buyerId': Authorization.buyerId};
    var tempNotif = await _notificationProvider?.get(searchObject);
    setState(() {
      _notifications = tempNotif!.reversed.toList();
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
      selectedIndex: 3,
      child: SingleChildScrollView(
        child: Column(
          children: [
            _buildHeader(),
            Divider(
              indent: 25,
              endIndent: 25,
              thickness: 3,
              color: Colors.grey,
            ),
            Column(
              children: _buildNotificationsList(),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.only(top: 7, bottom: 7),
      child: Center(
        child: Text(
          "Notifications",
          style: Theme.of(context).textTheme.headline6,
        ),
      ),
    );
  }

  List<Widget> _buildNotificationsList() {
    if (_notifications.isEmpty) {
      return [
        Center(
          child: Text(
            "Loading...",
            style: Theme.of(context).textTheme.headline4,
          ),
        )
      ];
    }
    var list = _notifications
        .map((x) => Container(
              padding: EdgeInsets.only(left: 15, right: 15, top: 15),
              child: ListTile(
                leading: Icon(Icons.info_outlined),
                title: Text(
                  "${formatter.format(x.notificationDateTime!)}",
                  style: TextStyle(color: Colors.black),
                ),
                subtitle: Text(x.notificationDesc!),
                trailing: Icon(Icons.label_important),
                isThreeLine: true,
                onTap: () {
                  showDialog(
                      context: context,
                      builder: (BuildContext context) => AlertDialog(
                            title: Text(
                                "Received on: ${formatter.format(x.notificationDateTime!)}"),
                            content: Text(
                                style: Theme.of(context).textTheme.subtitle2,
                                x.notificationDesc!),
                            actions: [
                              TextButton(
                                  onPressed: () => Navigator.pop(context),
                                  child: Text("Ok"))
                            ],
                          ));
                },
                style: ListTileStyle.drawer,
                shape: RoundedRectangleBorder(
                    side: BorderSide(
                        color: Color.fromARGB(255, 249, 219, 128), width: 3),
                    borderRadius: BorderRadius.circular(10)),
              ),
            ))
        .cast<Widget>()
        .toList();
    return list;
  }
}
