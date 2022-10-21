import 'package:ecodes_mobile/model/loyaltyPoints.dart';
import 'package:ecodes_mobile/model/user.dart';
import 'package:ecodes_mobile/providers/user_provider.dart';
import 'package:ecodes_mobile/screens/order/orders_screen.dart';
import 'package:ecodes_mobile/screens/user/user_profile_details_screen.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../providers/loyatlyPoints_provider.dart';
import '../../utils/util.dart';

class UserProfileScreen extends StatefulWidget {
  static const String routeName = "/user_profile";
  String id;

  UserProfileScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<UserProfileScreen> createState() => _UserProfileScreenState();
}

class _UserProfileScreenState extends State<UserProfileScreen> {
  UserProvider? _userProvider = null;
  LoyaltyPointsProvider? _loyaltyPointsProvider = null;
  User _user = new User();
  LoyaltyPoints _loyaltyPoints = new LoyaltyPoints();
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _userProvider = context.read<UserProvider>();
    _loyaltyPointsProvider = context.read<LoyaltyPointsProvider>();
    loadUser(this.widget.id);
  }

  void loadUser(String id) async {
    var identity = int.parse(id);
    var searchRequest = {'buyerId': Authorization.buyerId};
    var tmpuser = await _userProvider?.getById(identity);
    var tmppoints = await _loyaltyPointsProvider?.get(searchRequest);
    setState(() {
      _user = tmpuser!;
      _loyaltyPoints = tmppoints!.first;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
        selectedIndex: 3,
        child: SingleChildScrollView(
          child: Container(
            child: _buildProfileScreen(),
          ),
        ));
  }

  Widget _buildProfileScreen() {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        _buildHeader(),
        Flexible(
          fit: FlexFit.loose,
          child: Divider(
            color: Colors.grey,
            thickness: 2,
          ),
        ),
        _buildCard(),
        Flexible(
          fit: FlexFit.loose,
          child: Divider(
            color: Colors.grey,
            thickness: 2,
          ),
        ),
        _buildEditProfileButton(),
        Flexible(
          fit: FlexFit.loose,
          child: Divider(
            color: Colors.grey,
            thickness: 2,
          ),
        ),
        _buildPointsButton(),
        Flexible(
          fit: FlexFit.loose,
          child: Divider(
            color: Colors.grey,
            thickness: 2,
          ),
        ),
        _buildMyOrdersButton(),
        Flexible(
            fit: FlexFit.loose,
            child: Divider(
              color: Colors.grey,
              thickness: 2,
            )),
        _buildSupport()
      ],
    );
  }

  Widget _buildHeader() {
    return Container(
      margin: EdgeInsets.all(10),
      child: Text(
        "My Profile",
        style: Theme.of(context).textTheme.headline6,
      ),
    );
  }

  Widget _buildCard() {
    if (_user.person == null) {
      return Container(
        margin: EdgeInsets.all(15),
        child: Center(
            child: Text(
          "Loading...",
          style: Theme.of(context).textTheme.headline6,
        )),
      );
    }

    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      mainAxisSize: MainAxisSize.min,
      children: [
        Column(
          children: [
            Container(
              margin: EdgeInsets.all(15),
              child: Text(
                "Welcome, ${_user.person!.firstName} ${_user.person!.lastName}",
                style: Theme.of(context).textTheme.bodyText2,
              ),
            ),
            Container(
              margin: EdgeInsets.all(15),
              child: SizedBox(
                height: 35,
                child: ElevatedButton.icon(
                  onPressed: () {
                    Navigator.popUntil(context, (route) => route.isFirst);
                  },
                  icon: Icon(
                    Icons.logout,
                    size: 24.0,
                  ),
                  label: Text('Log out'),
                  style: ButtonStyle(),
                ),
              ),
            ),
          ],
        ),
      ],
    );
  }

  Widget _buildEditProfileButton() {
    return Container(
        child: InkWell(
      onTap: () {
        Navigator.pushNamed(context,
            "${UserProfileDetailsScreen.routeName}/${_user.buyerId}"); //<- Go to Editing user page
      },
      child: ListTile(
        leading: Icon(Icons.account_box_rounded),
        title: Text(
          "Account",
          style: Theme.of(context).textTheme.bodyText2,
        ),
        trailing: Icon(Icons.arrow_forward_ios),
      ),
    ));
  }

  Widget _buildPointsButton() {
    return Container(
        child: InkWell(
      onTap: () {
        showDialog(
            context: context,
            builder: (BuildContext context) => AlertDialog(
                  title: Text(
                    "Loyalty Points Details",
                    style: Theme.of(context).textTheme.headline4,
                  ),
                  content: Text(
                    "Your Loyalty Points balance: ${_loyaltyPoints.balance}\nLoyalty Points can be used as a percentage discount on your purchase (25 points = 25% dicount). Maximum allowed points per purchase are 75.",
                    style: TextStyle(
                        color: Color.fromARGB(255, 19, 65, 113), fontSize: 18),
                  ),
                  actions: [
                    TextButton(
                        onPressed: () => Navigator.pop(context),
                        child: Text("Ok")),
                  ],
                ));
      },
      child: ListTile(
        leading: Icon(Icons.loyalty_rounded),
        title: Text(
          "My Loyalty Points",
          style: Theme.of(context).textTheme.bodyText2,
        ),
        trailing: Icon(Icons.arrow_forward_ios),
      ),
    ));
  }

  Widget _buildMyOrdersButton() {
    return Container(
        child: InkWell(
      onTap: () {
        Navigator.pushNamed(context,
            OrdersScreen.routeName); //<- Go to Orders page for this user
      },
      child: ListTile(
        leading: Icon(Icons.menu_rounded),
        title: Text(
          "My Orders",
          style: Theme.of(context).textTheme.bodyText2,
        ),
        trailing: Icon(Icons.arrow_forward_ios),
      ),
    ));
  }

  Widget _buildSupport() {
    return Center(
      child: InkWell(
        onTap: () {
          // Navigate to support page
        },
        child: Container(
          margin: EdgeInsets.all(10),
          //padding: EdgeInsets.all(8),
          decoration: BoxDecoration(
            color: Color.fromARGB(255, 124, 142, 244),
            borderRadius: BorderRadius.all(Radius.circular(15)),
          ),
          child: Center(
            child: ListTile(
              leading: Icon(size: 55, color: Colors.black, Icons.help_outline),
              title: Center(
                  child: Text(
                      style: Theme.of(context).textTheme.bodyText2,
                      "Need some help ?")),
              subtitle: Center(
                  child: Text(
                      style: Theme.of(context).textTheme.bodyText2,
                      "Feel free to contact us")),
              trailing: Icon(
                  size: 55, color: Colors.black, Icons.support_agent_rounded),
            ),
          ),
        ),
      ),
    );
  }
}
