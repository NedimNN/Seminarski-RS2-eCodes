// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'wallet.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Wallet _$WalletFromJson(Map<String, dynamic> json) => Wallet()
  ..balance = (json['balance'] as num?)?.toDouble()
  ..currencyId = json['currencyId'] as int?
  ..buyerId = json['buyerId'] as int?;

Map<String, dynamic> _$WalletToJson(Wallet instance) => <String, dynamic>{
      'balance': instance.balance,
      'currencyId': instance.currencyId,
      'buyerId': instance.buyerId,
    };
