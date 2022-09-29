import 'package:ecodes_mobile/providers/rating_provider.dart';
import 'package:ecodes_mobile/screens/order/order_items_screen.dart';
import 'package:ecodes_mobile/screens/order/orders_screen.dart';
import 'package:ecodes_mobile/screens/products/product_details_screen.dart';
import 'package:ecodes_mobile/utils/util.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:provider/provider.dart';

import '../../model/rating.dart';

class RatingScreen extends StatefulWidget {
  String buyerID;
  String productID;
  RatingScreen(this.buyerID, this.productID, {Key? key}) : super(key: key);

  @override
  State<RatingScreen> createState() => _RatingScreenState();
}

class _RatingScreenState extends State<RatingScreen> {
  RatingProvider? _ratingProvider = null;
  Rating _rating = new Rating();
  TextEditingController _descriptionController = new TextEditingController();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _ratingProvider = context.read<RatingProvider>();
    setState(() {
      _rating.mark = 3;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Container(
        height: 400,
        child: Column(
          children: [
            SizedBox(height: 15),
            _buildHeader(),
            SizedBox(height: 15),
            _buildRatingBar(),
          ],
        ),
      ),
    );
  }

  Widget _buildHeader() {
    return SizedBox(
        height: 55,
        child: Center(
          child: Text(
              style: Theme.of(context).textTheme.headline6,
              "Rate this product"),
        ));
  }

  Widget _buildRatingBar() {
    return Column(
      children: [
        RatingBar.builder(
            initialRating: 3,
            itemCount: 5,
            allowHalfRating: true,
            itemBuilder: (context, index) {
              switch (index) {
                case 0:
                  return Icon(
                    Icons.sentiment_very_dissatisfied,
                    color: Colors.red,
                  );
                case 1:
                  return Icon(
                    Icons.sentiment_dissatisfied,
                    color: Colors.redAccent,
                  );
                case 2:
                  return Icon(
                    Icons.sentiment_neutral,
                    color: Colors.amber,
                  );
                case 3:
                  return Icon(
                    Icons.sentiment_satisfied,
                    color: Colors.lightGreen,
                  );
                case 4:
                  return Icon(
                    Icons.sentiment_very_satisfied,
                    color: Colors.green,
                  );
              }
              return Container(
                padding: EdgeInsets.only(left: 25),
                child: Text(
                    style: Theme.of(context).textTheme.headline1, "Loading..."),
              );
            },
            onRatingUpdate: (rating) {
              print(rating);
              _rating.mark = rating;
            }),
        SizedBox(height: 25),
        Text(style: Theme.of(context).textTheme.bodyText2, "Description: "),
        SizedBox(height: 5),
        Container(
          height: 125,
          width: 225,
          padding: EdgeInsets.only(bottom: 15, left: 5, right: 5),
          decoration: BoxDecoration(
              border: Border(
                top: BorderSide(),
                right: BorderSide(),
                bottom: BorderSide(),
                left: BorderSide(),
              ),
              borderRadius: BorderRadius.all(Radius.circular(15))),
          child: TextFormField(
            controller: _descriptionController,
            keyboardType: TextInputType.multiline,
            maxLines: null,
            minLines: 4,
            style: Theme.of(context).textTheme.subtitle2,
            validator: (value) {
              if (value!.isEmpty) {
                return 'Please enter some text';
              }
              return null;
            },
          ),
        ),
        SizedBox(height: 25),
        Container(
          child: ElevatedButton.icon(
            onPressed: () async {
              try {
                if (int.parse(widget.buyerID) != 0 &&
                    int.parse(widget.productID) != 0) {
                  _rating.buyerId = int.parse(widget.buyerID);
                  _rating.productId = int.parse(widget.productID);
                  _rating.date = DateTime.now();
                  _rating.description = _descriptionController.text;
                } else {
                  throw new Exception(
                      "Sorry, the rating system is not working now!");
                }

                var ratingResponse = await _ratingProvider?.insert(_rating);
                if (ratingResponse != null) {
                  showDialog(
                      context: context,
                      builder: (BuildContext context) => AlertDialog(
                            title: Text("Rating added successfully ! "),
                            content: Text(
                                style: Theme.of(context).textTheme.subtitle2,
                                "Thank you for leaving a rating, it makes it easier for other customers to shop"),
                            actions: [
                              TextButton(
                                  onPressed: () {
                                    int count = 0;
                                    Navigator.of(context)
                                        .popUntil((_) => count++ >= 2);
                                  },
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
                              style: Theme.of(context).textTheme.subtitle2,
                              e.toString()),
                          actions: [
                            TextButton(
                                onPressed: () => Navigator.pop(context),
                                child: Text("Ok"))
                          ],
                        ));
              }
            },
            icon: Icon(
              Icons.star_rate_rounded,
              size: 23.0,
            ),
            label: Text('Rate'),
          ),
        )
      ],
    );
  }
}
