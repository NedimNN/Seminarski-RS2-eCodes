// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'rating.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Rating _$RatingFromJson(Map<String, dynamic> json) => Rating()
  ..productId = json['productId'] as int?
  ..buyerId = json['buyerId'] as int?
  ..date = json['date'] == null ? null : DateTime.parse(json['date'] as String)
  ..description = json['description'] as String?
  ..mark = (json['mark'] as num?)?.toDouble()
  ..buyer = json['buyer'] == null
      ? null
      : User.fromJson(json['buyer'] as Map<String, dynamic>);

Map<String, dynamic> _$RatingToJson(Rating instance) => <String, dynamic>{
      'productId': instance.productId,
      'buyerId': instance.buyerId,
      'date': instance.date?.toIso8601String(),
      'description': instance.description,
      'mark': instance.mark,
      'buyer': instance.buyer?.toJson(),
    };
