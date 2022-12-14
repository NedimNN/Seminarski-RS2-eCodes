import 'dart:convert';
import 'dart:typed_data';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';

class Authorization {
  static String? username;
  static String? password;
  static int? buyerId;
}

Image imageFromBase64String(String base64String) {
  return Image.memory(base64Decode(base64String),fit: BoxFit.cover,);
}

Uint8List dataFromBase64String(String base64String) {
  return base64Decode(base64String);
}

String base64String(Uint8List data) {
  return base64Encode(data);
}

String formatNumber(dynamic) {
  var f = NumberFormat('###.0#');
  if (dynamic == null) {
    return "";
  }

  return f.format(dynamic);
}
Future<double?> exchangeToUSD (double amount,String fromCurrency)async{
  if(fromCurrency.isEmpty || amount <= 0.00){
    return 0.00;
  }else if(fromCurrency == "EUR"){
    var convertedToUSD = amount * 1.038 ;
    return double.parse(convertedToUSD.toStringAsFixed(2));
  }
  return 0.00;
}

