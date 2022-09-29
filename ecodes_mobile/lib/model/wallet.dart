import 'package:json_annotation/json_annotation.dart';

part 'wallet.g.dart';

@JsonSerializable()
class Wallet{
  double? balance;
  int? currencyId;
  int? buyerId;

  Wallet(){

  }
  
 factory Wallet.fromJson(Map<String, dynamic> json) => _$WalletFromJson(json);

  /// Connect the generated [_$WalletToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$WalletToJson(this);

}