// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'notification.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Notif _$NotifFromJson(Map<String, dynamic> json) => Notif()
  ..notificationId = json['notificationId'] as int?
  ..notificationDesc = json['notificationDesc'] as String?
  ..notificationDateTime = json['notificationDateTime'] == null
      ? null
      : DateTime.parse(json['notificationDateTime'] as String)
  ..buyerId = json['buyerId'] as int?;

Map<String, dynamic> _$NotifToJson(Notif instance) => <String, dynamic>{
      'notificationId': instance.notificationId,
      'notificationDesc': instance.notificationDesc,
      'notificationDateTime': instance.notificationDateTime?.toIso8601String(),
      'buyerId': instance.buyerId,
    };
