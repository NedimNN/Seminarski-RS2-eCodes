import 'package:ecodes_mobile/model/seller.dart';
import 'package:json_annotation/json_annotation.dart';
//import 'package:json_serializable/json_serializable.dart';

part 'product.g.dart';


@JsonSerializable(explicitToJson: true)
class Product{
  int? productId;
  String? name;
  String? picture;
  double? price;
  String? description;
  String? duration;
  String? productTypeName;
  Seller? seller;
  String? stateMachine;

  Product(){
    
  }


  factory Product.fromJson(Map<String, dynamic> json) => _$ProductFromJson(json);

  /// Connect the generated [_$ProductToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ProductToJson(this);

}