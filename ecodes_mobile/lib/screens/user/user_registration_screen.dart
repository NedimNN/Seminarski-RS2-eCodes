import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../model/requests/user_insert_request.dart';
import '../../model/user.dart';
import '../../providers/user_provider.dart';
import '../../widgets/master_bottom_drawer.dart';

class UserRegistrationScreen extends StatefulWidget {
  static String routeName = "/user_registration";
  const UserRegistrationScreen({Key? key}) : super(key: key);

  @override
  State<UserRegistrationScreen> createState() => _UserRegistrationScreenState();
}

class _UserRegistrationScreenState extends State<UserRegistrationScreen> {
  UserProvider? _userProvider = null;
  UserInsertRequest _userData = new UserInsertRequest();
  TextEditingController _firstnameController = new TextEditingController();
  TextEditingController _lastnameController = new TextEditingController();
  TextEditingController _dateofbirthController = new TextEditingController();
  TextEditingController _cityNameController = new TextEditingController();
  TextEditingController _jmbgController = new TextEditingController();
  TextEditingController _genderController = new TextEditingController();
  TextEditingController _emailController = new TextEditingController();
  TextEditingController _usernameController = new TextEditingController();
  TextEditingController _passwordController = new TextEditingController();
  TextEditingController _passwordConfirmController =
      new TextEditingController();

  final _formKey = GlobalKey<FormState>(); // form key for validation

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _userProvider = context.read<UserProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Container(
          child: SingleChildScrollView(child: _buildRegisterUserForm()),
        ),
      ),
    );
  }

  Widget _buildHeaderRegister() {
    return Container(
      padding: EdgeInsets.all(10),
      child: Center(
        child: Text(
          "Register form",
          style: Theme.of(context).textTheme.headline6,
        ),
      ),
    );
  }

  Widget _buildRegisterUserForm() {
    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          _buildHeaderRegister(),
          Divider(
            color: Colors.grey,
            thickness: 2,
          ),
          Container(
            padding: EdgeInsets.only(top: 15, right: 5),
            child: SizedBox(
              height: 60,
              child: TextFormField(
                style: Theme.of(context).textTheme.headline4,
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
                style: Theme.of(context).textTheme.headline4,
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
                style: Theme.of(context).textTheme.headline4,
                controller: _dateofbirthController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.calendar_today,
                      size: 35,
                    ),
                    hintText: 'yyyy-mm-dd',
                    labelText: 'Dob',
                    isDense: true,
                    contentPadding: EdgeInsets.all(8)),
                validator: (value) {
                   var datetime = 0;
                  if (value != null) {
                    try {
                     datetime =  DateTime.parse(value).compareTo(DateTime.now());
                    } catch (e) {
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
                    var date = value.split("-");
                    if (int.parse(date[1]) > 12) {
                      return 'Month can\'t be above 12';
                    } else if (int.parse(date[2]) > 31) {
                      return 'Day can\'t be above 31';
                    } else if (datetime >= 0) {
                      return 'This date is not valid!';
                    }
                  }
                  else{
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
                style: Theme.of(context).textTheme.headline4,
                controller: _cityNameController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.location_city_rounded,
                      size: 35,
                    ),
                    hintText: 'Enter your City name',
                    labelText: 'City Name',
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
                style: Theme.of(context).textTheme.headline4,
                controller: _jmbgController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.numbers_rounded,
                      size: 35,
                    ),
                    hintText: 'Enter your JMBG',
                    labelText: 'JMBG',
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
                style: Theme.of(context).textTheme.headline4,
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
                style: Theme.of(context).textTheme.headline4,
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
                style: Theme.of(context).textTheme.headline4,
                controller: _usernameController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.account_circle_rounded,
                      size: 35,
                    ),
                    hintText: 'Enter your username',
                    labelText: 'Username',
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
                style: Theme.of(context).textTheme.headline4,
                controller: _passwordController,
                obscureText: true,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    icon: Icon(
                      Icons.password_rounded,
                      size: 35,
                    ),
                    hintText: 'Enter your password',
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
                style: Theme.of(context).textTheme.headline4,
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
                margin: EdgeInsets.only(top: 55, bottom: 25),
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
                          _userData.cityName = _cityNameController.text;
                          _userData.jmbg = _jmbgController.text;
                          _userData.gender = _genderController.text;
                          _userData.email = _emailController.text;
                          _userData.username = _usernameController.text;
                          _userData.password = _passwordController.text;
                          _userData.passwordConfirmation =
                              _passwordConfirmController.text;
                          var user = await _userProvider!.insert(_userData);
                          if (user != null) {
                            showDialog(
                                context: context,
                                builder: (BuildContext context) => AlertDialog(
                                      title:
                                          Text("User registration successful!"),
                                      content: Text(
                                          style: Theme.of(context)
                                              .textTheme
                                              .subtitle2,
                                          "Successfully registered user ${user.person!.firstName}"),
                                      actions: [
                                        TextButton(
                                            onPressed: () => Navigator.popUntil(
                                                context,
                                                (route) => route.isFirst),
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
