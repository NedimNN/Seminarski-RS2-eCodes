import 'providers/cart_provider.dart';
import 'providers/currency_provider.dart';
import 'providers/notification_provider.dart';
import 'providers/orderItems_provider.dart';
import 'providers/order_provider.dart';
import 'providers/payment_provider.dart';
import 'providers/product_provider.dart';
import 'providers/rating_provider.dart';
import 'providers/loyatlyPoints_provider.dart';
import 'providers/seller_provider.dart';
import 'providers/user_provider.dart';
import 'screens/cart/cart_screen.dart';
import 'screens/notifications/notifications_screen.dart';
import 'screens/order/order_items_screen.dart';
import 'screens/order/orders_screen.dart';
import 'screens/products/product_details_screen.dart';
import 'screens/products/product_list_screen.dart';
import 'screens/products/products_search_screen.dart';
import 'screens/seller/seller_profile_screen.dart';
import 'screens/user/user_profile_details_screen.dart';
import 'screens/user/user_profile_screen.dart';
import 'screens/user/user_registration_screen.dart';
import 'utils/util.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:collection/collection.dart';


void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => ProductProvider()),
        ChangeNotifierProvider(create: (_) => UserProvider()),
        ChangeNotifierProvider(create: (_) => CartProvider()),
        ChangeNotifierProvider(create: (_) => OrderProvider()),
        ChangeNotifierProvider(create: (_) => OrderItemProvider()),
        ChangeNotifierProvider(create: (_) => RatingProvider()),
        ChangeNotifierProvider(create: (_) => CurrencyProvider()),
        ChangeNotifierProvider(create: (_) => LoyaltyPointsProvider()),
        ChangeNotifierProvider(create: (_) => PaymentProvider()),
        ChangeNotifierProvider(create: (_) => SellerProvider()),
        ChangeNotifierProvider(create: (_) => NotificationProvider()),      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        theme: ThemeData(
          // Define the default brightness and colors.
          brightness: Brightness.light,

          // Define the default `TextTheme`. Use this to specify the default
          // text styling for headlines, titles, bodies of text, and more.
          textTheme: const TextTheme(
            headline1: TextStyle(
                color: Colors.blue, fontSize: 35, fontWeight: FontWeight.bold),
            headline2: TextStyle(
                color: Colors.black, fontSize: 35, fontWeight: FontWeight.bold),
            headline3: TextStyle(
                color: Colors.white, fontSize: 35, fontWeight: FontWeight.bold),
            headline4: TextStyle(
                color: Colors.black, fontWeight: FontWeight.bold,fontStyle: FontStyle.italic, fontSize: 25),
            headline5: TextStyle(
                color: Colors.white, fontSize: 25, fontWeight: FontWeight.bold),
            headline6: TextStyle(
                color: Color.fromARGB(255, 4, 104, 150),
                fontSize: 36.0,
                fontStyle: FontStyle.italic,
                fontWeight: FontWeight.bold),
            bodyText1: TextStyle(
                color: Colors.white, fontWeight: FontWeight.bold, fontSize: 22),
            bodyText2: TextStyle(
                color: Colors.black,
                fontStyle: FontStyle.italic,
                fontWeight: FontWeight.bold,
                fontSize: 22),
            subtitle1: TextStyle(
                color: Colors.white, fontWeight: FontWeight.bold, fontSize: 15),
            subtitle2: TextStyle(
                color: Colors.black, fontWeight: FontWeight.bold, fontSize: 18),
          ),
        ),
        home: HomePage(),
        onGenerateRoute: (settings) {
          if (settings.name == ProductListScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => ProductListScreen()));
          } else if (settings.name == CartScreen.routeName) {
            return MaterialPageRoute(builder: ((context) => CartScreen()));
          } else if (settings.name == ProductsSearchScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => ProductsSearchScreen()));
          } else if (settings.name == OrdersScreen.routeName) {
            return MaterialPageRoute(builder: ((context) => OrdersScreen()));
          } else if (settings.name == UserRegistrationScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => UserRegistrationScreen()));
          }else if (settings.name == NotificationScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => NotificationScreen()));
          }

          var uri = Uri.parse(settings.name!);
          if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == ProductDetailsScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => ProductDetailsScreen(id));
          } else if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == UserProfileScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => UserProfileScreen(id));
          } else if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" ==
                  UserProfileDetailsScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => UserProfileDetailsScreen(id));
          } else if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == OrderItemsScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => OrderItemsScreen(id));
          } else if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == SellerProfileScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => SellerProfileScreen(id));
          }
        },
      ),
    ));

class HomePage extends StatelessWidget {
  TextEditingController _usernameController = new TextEditingController();
  TextEditingController _passwordController = new TextEditingController();
  late UserProvider _userProvider;
  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);
    void _buildLoading(bool isLoading) {
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

    return Scaffold(
        appBar: AppBar(
          title: Text("eCodes Home"),
        ),
        body: SingleChildScrollView(
          child: Column(
            children: [
              Container(
                height: MediaQuery.of(context).size.height,
                width: MediaQuery.of(context).size.width,
                decoration: BoxDecoration(
                    image: DecorationImage(
                        fit: BoxFit.fill,
                        image:
                            AssetImage("assets/images/giftcards_image.png"))),
                child: Stack(
                  children: [
                    Container(
                      height: 150,
                      margin: EdgeInsets.fromLTRB(5, 55, 5, 0),
                      decoration: BoxDecoration(
                        color: Color.fromARGB(195, 4, 104, 150),
                        borderRadius: BorderRadius.circular(25),
                      ),
                      child: Center(
                          heightFactor: 2.3,
                          child: Container(
                            child: Text(
                                textAlign: TextAlign.center,
                                style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 25,
                                ),
                                "Different gift cards for all your different needs !"),
                          )),
                    ),
                    Positioned(
                        bottom: 225,
                        right: 50,
                        left: 50,
                        child: Container(
                          decoration: BoxDecoration(
                            color: Color.fromARGB(192, 4, 104, 150),
                            borderRadius: BorderRadius.circular(25),
                          ),
                          child: Padding(
                            padding: EdgeInsets.all(8),
                            child: Column(children: [
                              Center(
                                heightFactor: 1.5,
                                child: Container(
                                  child: Text(
                                      style: TextStyle(
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold,
                                        fontSize: 25,
                                      ),
                                      "Login"),
                                ),
                              ),
                              Divider(
                                indent: 35,
                                endIndent: 35,
                                color: Colors.white,
                                thickness: 3.5,
                              ),
                              Container(
                                margin: EdgeInsets.only(top: 5),
                                padding: EdgeInsets.all(5),
                                child: TextField(
                                  controller: _usernameController,
                                  style: TextStyle(
                                    color: Colors.white,
                                    fontWeight: FontWeight.bold,
                                    fontSize: 25,
                                  ),
                                  decoration: InputDecoration(
                                      border: InputBorder.none,
                                      hintStyle: TextStyle(color: Colors.white),
                                      hintText: "Username"),
                                ),
                              ),
                              Divider(
                                color: Colors.white,
                                thickness: 2,
                              ),
                              Container(
                                padding: EdgeInsets.all(5),
                                child: TextField(
                                  obscureText: true,
                                  enableSuggestions: false,
                                  autocorrect: false,
                                  controller: _passwordController,
                                  style: TextStyle(
                                    color: Colors.white,
                                    fontWeight: FontWeight.bold,
                                    fontSize: 25,
                                  ),
                                  decoration: InputDecoration(
                                      border: InputBorder.none,
                                      hintStyle: TextStyle(color: Colors.white),
                                      hintText: "Password"),
                                ),
                              ),
                            ]),
                          ),
                        )),
                    Positioned(
                        bottom: 150,
                        left: 50,
                        right: 50,
                        child: Container(
                          height: 50,
                          decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(10),
                              gradient: LinearGradient(colors: [
                                Color.fromARGB(222, 1, 93, 206),
                                Color.fromARGB(222, 0, 172, 172)
                              ])),
                          child: InkWell(
                            onTap: () async {
                              try {
                                Authorization.username =
                                    _usernameController.text;
                                Authorization.password =
                                    _passwordController.text;
                                _buildLoading(true);
                                var users = await _userProvider.get();
                                Authorization.buyerId = users
                                    .firstWhereOrNull((user) =>
                                        user.username == Authorization.username)
                                    ?.buyerId;
                                _buildLoading(false);
                                Navigator.pushNamed(
                                    context, ProductListScreen.routeName);
                              } catch (e) {
                                // TODO
                                _buildLoading(false);
                                showDialog(
                                    context: context,
                                    builder: (BuildContext context) =>
                                        AlertDialog(
                                          title: Text("Error"),
                                          content: Text(
                                              style: Theme.of(context)
                                                  .textTheme
                                                  .subtitle2,
                                              e.toString()),
                                          actions: [
                                            TextButton(
                                                onPressed: () =>
                                                    Navigator.pop(context),
                                                child: Text("Ok"))
                                          ],
                                        ));
                              }
                            },
                            child: Center(
                                child: Text(
                                    style: TextStyle(
                                      color: Colors.white,
                                      fontWeight: FontWeight.bold,
                                      fontSize: 25,
                                    ),
                                    "Login")),
                          ),
                        )),
                    Positioned(
                        bottom: 90,
                        left: 50,
                        right: 50,
                        child: Center(
                          child: Container(
                            padding: EdgeInsets.all(5),
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(10),
                                gradient: LinearGradient(colors: [
                                  Color.fromARGB(222, 1, 93, 206),
                                  Color.fromARGB(222, 0, 172, 172)
                                ])),
                            child: InkWell(
                              onTap: () {
                                Navigator.pushNamed(
                                    context, UserRegistrationScreen.routeName);
                              },
                              child: Text(
                                  style: TextStyle(
                                    color: Colors.white,
                                    fontWeight: FontWeight.bold,
                                    fontSize: 15,
                                  ),
                                  "Don't have an account, Register here!"),
                            ),
                          ),
                        ))
                  ],
                ),
              ),
            ],
          ),
        )
        );
  }
}
