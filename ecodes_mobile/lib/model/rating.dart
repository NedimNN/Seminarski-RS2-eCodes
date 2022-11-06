import 'package:ecodes_mobile/model/product.dart';
import 'package:ecodes_mobile/model/seller.dart';
import 'package:ecodes_mobile/model/user.dart';
import 'package:json_annotation/json_annotation.dart';



part 'rating.g.dart';

@JsonSerializable(explicitToJson: true)
class Rating {
  int? productId;
  int? buyerId;
  int? sellerId;
  DateTime? date;
  String? description; 
  double? mark;
  User? buyer;
  Product? product;
  Seller? seller;

  Rating(){

  }

 factory Rating.fromJson(Map<String, dynamic> json) => _$RatingFromJson(json);

  /// Connect the generated [_$RatingToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RatingToJson(this);


}