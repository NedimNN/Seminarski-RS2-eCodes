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
  ..giftCardKey = json['giftCardKey'] as String?
  ..seller = json['seller'] == null
      ? null
      : Seller.fromJson(json['seller'] as Map<String, dynamic>)
  ..stateMachine = json['stateMachine'] as String?
  ..productType = json['productType'] == null
      ? null
      : ProductType.fromJson(json['productType'] as Map<String, dynamic>);

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
      'productId': instance.productId,
      'name': instance.name,
      'picture': instance.picture,
      'price': instance.price,
      'description': instance.description,
      'duration': instance.duration,
      'productTypeName': instance.productTypeName,
      'giftCardKey': instance.giftCardKey,
      'seller': instance.seller?.toJson(),
      'stateMachine': instance.stateMachine,
      'productType': instance.productType?.toJson(),
    };
