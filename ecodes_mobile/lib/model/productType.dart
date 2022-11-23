import './currency.dart';
import 'package:json_annotation/json_annotation.dart';


part 'productType.g.dart';


@JsonSerializable()
class ProductType{
  String? name;
  String? region;
  int? currencyId;
  Currency? currency;
  
  ProductType(){

  }

  factory ProductType.fromJson(Map<String, dynamic> json) => _$ProductTypeFromJson(json);

  /// Connect the generated [_$ProductTypeToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ProductTypeToJson(this);

}