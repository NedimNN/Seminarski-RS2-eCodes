// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'payment.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Payment _$PaymentFromJson(Map<String, dynamic> json) => Payment()
  ..paymentMethodNonce = json['paymentMethodNonce'] as String?
  ..amount = (json['amount'] as num?)?.toDouble()
  ..buyerId = json['buyerId'] as int?
  ..successful = json['successful'] as bool?
  ..productId = json['productId'] as int?
  ..usedLoyaltyPoints = (json['usedLoyaltyPoints'] as num?)?.toDouble();

Map<String, dynamic> _$PaymentToJson(Payment instance) => <String, dynamic>{
      'paymentMethodNonce': instance.paymentMethodNonce,
      'amount': instance.amount,
      'buyerId': instance.buyerId,
      'successful': instance.successful,
      'productId': instance.productId,
      'usedLoyaltyPoints': instance.usedLoyaltyPoints,
    };
