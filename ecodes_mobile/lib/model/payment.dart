import 'package:json_annotation/json_annotation.dart';



part 'payment.g.dart';

@JsonSerializable()
class Payment{
  String? paymentMethodNonce;
  String? deviceData;
  double? amount;
  int? buyerId;
  bool? successful;
  int? productId;
  double? usedLoyaltyPoints;

  Payment(){

  }
  factory Payment.fromJson(Map<String, dynamic> json) => _$PaymentFromJson(json);

  /// Connect the generated [_$PaymentToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PaymentToJson(this);


}

