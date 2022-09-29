import 'package:ecodes_mobile/model/product.dart';
import 'package:json_annotation/json_annotation.dart';


part 'orderItem.g.dart';

@JsonSerializable(explicitToJson: true)
class OrderItem{
  int? orderItemId;
  int? orderId;
  int? productId;
  int? quantity;
  Product? product;

  OrderItem(){
    
  }

   factory OrderItem.fromJson(Map<String, dynamic> json) => _$OrderItemFromJson(json);

  /// Connect the generated [_$OrderItemToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$OrderItemToJson(this);

}