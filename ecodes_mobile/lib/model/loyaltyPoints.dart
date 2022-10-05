import 'package:json_annotation/json_annotation.dart';



part 'loyaltyPoints.g.dart';

@JsonSerializable()
class LoyaltyPoints{
  int? loyaltyPointsId;
  double? balance;
  int? buyerId;

  LoyaltyPoints(){

  }

   factory LoyaltyPoints.fromJson(Map<String, dynamic> json) => _$LoyaltyPointsFromJson(json);

  /// Connect the generated [_$LoyaltyPointsToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$LoyaltyPointsToJson(this);


}
