// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User()
  ..buyerId = json['buyerId'] as int?
  ..registrationDate = json['registrationDate'] == null
      ? null
      : DateTime.parse(json['registrationDate'] as String)
  ..email = json['email'] as String?
  ..username = json['username'] as String?
  ..password = json['password'] as String?
  ..passwordConfirmation = json['passwordConfirmation'] as String?
  ..status = json['status'] as bool?
  ..person = json['person'] == null
      ? null
      : Person.fromJson(json['person'] as Map<String, dynamic>);

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'buyerId': instance.buyerId,
      'registrationDate': instance.registrationDate?.toIso8601String(),
      'email': instance.email,
      'username': instance.username,
      'password': instance.password,
      'passwordConfirmation': instance.passwordConfirmation,
      'status': instance.status,
      'person': instance.person?.toJson(),
    };
