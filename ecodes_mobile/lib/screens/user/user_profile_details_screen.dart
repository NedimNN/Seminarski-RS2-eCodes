import '../../model/requests/user_update_request.dart';
import '../../widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/user.dart';
import '../../providers/user_provider.dart';

class UserProfileDetailsScreen extends StatefulWidget {
  static String routeName = "/user_profile_details";
  String id;
  UserProfileDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<UserProfileDetailsScreen> createState() =>
      _UserProfileDetailsScreenState();
}

class _UserProfileDetailsScreenState extends State<UserProfileDetailsScreen> {
  UserProvider? _userProvider = null;
  User _user = new User();
  UserUpdateRequest _userData = new UserUpdateRequest();
  TextEditingController _firstnameController = new TextEditingController();
  TextEditingController _lastnameController = new TextEditingController();
  TextEditingController _dateofbirthController = new TextEditingController();
  TextEditingController _genderController = new TextEditingController();
  TextEditingController _emailController = new TextEditingController();
  TextEditingController _passwordController = new TextEditingController();
  TextEditingController _passwordConfirmController =
      new TextEditingController();

  final _formKey = GlobalKey<FormState>(); // form key for validation

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _userProvider = context.read<UserProvider>();
    loadUser(this.widget.id);
  }

  void loadUser(String id) async {
    var identity = int.parse(id);
    var tmpuser = await _userProvider?.getById(identity);
    setState(() {
      _user = tmpuser!;
      _firstnameController.text = _user.person?.firstName! as String;
      _lastnameController.text = _user.person?.lastName! as String;
      _dateofbirthController.text =
          DateFormat('yyyy-MM-dd').format(_user.person!.dateOfBirth!);
      _genderController.text = _user.person?.gender! as String;
      _emailController.text = _user.email!;
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
            color: Colors.grey,
            thickness: 2,
          ),
          _buildEditUser(),
        ],
      )),
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.only(top: 5, bottom: 5),
      child: Center(
        child: Text(
            style: Theme.of(context).textTheme.headline6, "Edit your profile"),
      ),
    );
  }

  Widget _buildEditUser() {
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

    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Container(
            padding: EdgeInsets.only(top: 15, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.subtitle2,
                controller: _firstnameController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.person,
                      size: 35,
                    ),
                    hintText: 'Enter your firstname',
                    labelText: 'Firstname',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter some text';
                  }
                  return null;
                },
              ),
            ),
          ),
          Container(
            padding: EdgeInsets.only(top: 7, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.subtitle2,
                controller: _lastnameController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.person,
                      size: 35,
                    ),
                    hintText: 'Enter your lastname',
                    labelText: 'Lastame',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter some text';
                  }
                  return null;
                },
              ),
            ),
          ),
          Container(
            padding: EdgeInsets.only(top: 7, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.subtitle2,
                controller: _dateofbirthController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.calendar_today,
                      size: 35,
                    ),
                    hintText: 'Enter your date of birth',
                    labelText: 'Dob',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                validator: (value) {
                  var datetime = 0;
                  if (value != null) {
                    try {
                      datetime =
                          DateTime.parse(value).compareTo(DateTime.now());
                    } catch (e) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: Text("Error"),
                                content: Text(
                                    style:
                                        Theme.of(context).textTheme.subtitle2,
                                    e.toString()),
                                actions: [
                                  TextButton(
                                      onPressed: () => Navigator.pop(context),
                                      child: Text("Ok"))
                                ],
                              ));
                    }
                    var date = value.split("-");
                    if (int.parse(date[1]) > 12) {
                      return 'Month can\'t be above 12';
                    } else if (int.parse(date[2]) > 31) {
                      return 'Day can\'t be above 31';
                    } else if (datetime >= 0) {
                      return 'This date is not valid!';
                    }
                  } else {
                    return 'Please enter some text';
                  }
                  return null;
                },
              ),
            ),
          ),
          Container(
            padding: EdgeInsets.only(top: 7, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.subtitle2,
                controller: _genderController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.male_rounded,
                      size: 35,
                    ),
                    hintText: 'Enter your gender',
                    labelText: 'Gender',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter some text';
                  }
                  return null;
                },
              ),
            ),
          ),
          Container(
            padding: EdgeInsets.only(top: 7, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.subtitle2,
                controller: _emailController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.email_rounded,
                      size: 35,
                    ),
                    hintText: 'Enter your email',
                    labelText: 'Email',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter some text';
                  }
                  return null;
                },
              ),
            ),
          ),
          Container(
            padding: EdgeInsets.only(top: 7, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.subtitle2,
                controller: _passwordController,
                obscureText: true,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.password_rounded,
                      size: 35,
                    ),
                    hintText: 'Enter your new password',
                    labelText: 'Password',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                enableSuggestions: false,
                autocorrect: false,
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter some text';
                  } else if (value != _passwordConfirmController.text) {
                    return "Password and confirmation don't match";
                  }
                  return null;
                },
              ),
            ),
          ),
          Container(
            padding: EdgeInsets.only(top: 7, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.subtitle2,
                controller: _passwordConfirmController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.password_rounded,
                      size: 35,
                    ),
                    hintText: 'Confirm your password',
                    labelText: 'Password Confirmation',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                obscureText: true,
                enableSuggestions: false,
                autocorrect: false,
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter some text';
                  } else if (value != _passwordController.text) {
                    return "Password and confirmation don't match";
                  }
                  return null;
                },
              ),
            ),
          ),
          Center(
            child: Container(
                width: 300,
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    gradient: LinearGradient(colors: [
                      Color.fromARGB(222, 1, 93, 206),
                      Color.fromARGB(222, 0, 172, 172)
                    ])),
                margin: EdgeInsets.only(top: 15, bottom: 15),
                child: Center(
                  child: TextButton(
                    child: Text(
                        style: Theme.of(context).textTheme.bodyText1, 'Submit'),
                    onPressed: () async {
                      if (_formKey.currentState!.validate()) {
                        try {
                          _userData.firstName = _firstnameController.text;
                          _userData.lastName = _lastnameController.text;
                          _userData.dateOfBirth =
                              DateTime.parse(_dateofbirthController.text);
                          _userData.gender = _genderController.text;
                          _userData.email = _emailController.text;
                          _userData.password = _passwordController.text;
                          _userData.passwordConfirmation =
                              _passwordConfirmController.text;
                          var user = await _userProvider!
                              .update(_user.buyerId!, _userData);
                          if (user != null) {
                            showDialog(
                                context: context,
                                builder: (BuildContext context) => AlertDialog(
                                      title: Text("Updated!"),
                                      content: Text(
                                          style: Theme.of(context)
                                              .textTheme
                                              .subtitle2,
                                          "Successfully updated user ${user.person!.firstName}"),
                                      actions: [
                                        TextButton(
                                            onPressed: () =>
                                                Navigator.pop(context),
                                            child: Text("Ok"))
                                      ],
                                    ));
                          }
                        } catch (e) {
                          showDialog(
                              context: context,
                              builder: (BuildContext context) => AlertDialog(
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
                      }
                    },
                  ),
                )),
          ),
        ],
      ),
    );
  }
}
