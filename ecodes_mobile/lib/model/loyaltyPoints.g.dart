// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'loyaltyPoints.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LoyaltyPoints _$LoyaltyPointsFromJson(Map<String, dynamic> json) =>
    LoyaltyPoints()
      ..loyaltyPointsId = json['loyaltyPointsId'] as int?
      ..balance = (json['balance'] as num?)?.toDouble()
      ..buyerId = json['buyerId'] as int?;

Map<String, dynamic> _$LoyaltyPointsToJson(LoyaltyPoints instance) =>
    <String, dynamic>{
      'loyaltyPointsId': instance.loyaltyPointsId,
      'balance': instance.balance,
      'buyerId': instance.buyerId,
    };
