// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'productType.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ProductType _$ProductTypeFromJson(Map<String, dynamic> json) => ProductType()
  ..name = json['name'] as String?
  ..region = json['region'] as String?
  ..currencyId = json['currencyId'] as int?
  ..currency = json['currency'] == null
      ? null
      : Currency.fromJson(json['currency'] as Map<String, dynamic>);

Map<String, dynamic> _$ProductTypeToJson(ProductType instance) =>
    <String, dynamic>{
      'name': instance.name,
      'region': instance.region,
      'currencyId': instance.currencyId,
      'currency': instance.currency,
    };
