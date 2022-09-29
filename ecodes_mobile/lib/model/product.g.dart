// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Product _$ProductFromJson(Map<String, dynamic> json) => Product()
  ..productId = json['productId'] as int?
  ..name = json['name'] as String?
  ..picture = json['picture'] as String?
  ..price = (json['price'] as num?)?.toDouble()
  ..description = json['description'] as String?
  ..duration = json['duration'] as String?
  ..productTypeName = json['productTypeName'] as String?
  ..seller = json['seller'] == null
      ? null
      : Seller.fromJson(json['seller'] as Map<String, dynamic>)
  ..stateMachine = json['stateMachine'] as String?;

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
      'productId': instance.productId,
      'name': instance.name,
      'picture': instance.picture,
      'price': instance.price,
      'description': instance.description,
      'duration': instance.duration,
      'productTypeName': instance.productTypeName,
      'seller': instance.seller?.toJson(),
      'stateMachine': instance.stateMachine,
    };
