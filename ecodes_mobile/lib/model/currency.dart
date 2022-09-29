import 'package:json_annotation/json_annotation.dart';

part 'currency.g.dart';


@JsonSerializable()
class Currency{
  String? name;
  String? abbreviation;

  Currency(){

  }

  factory Currency.fromJson(Map<String, dynamic> json) => _$CurrencyFromJson(json);

  /// Connect the generated [_$CurrencyToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CurrencyToJson(this);

}