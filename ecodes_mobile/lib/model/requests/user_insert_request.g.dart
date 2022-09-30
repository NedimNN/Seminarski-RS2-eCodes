// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_insert_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserInsertRequest _$UserInsertRequestFromJson(Map<String, dynamic> json) =>
    UserInsertRequest()
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..dateOfBirth = json['dateOfBirth'] == null
          ? null
          : DateTime.parse(json['dateOfBirth'] as String)
      ..cityName = json['cityName'] as String?
      ..jmbg = json['jmbg'] as String?
      ..gender = json['gender'] as String?
      ..email = json['email'] as String?
      ..username = json['username'] as String?
      ..password = json['password'] as String?
      ..passwordConfirmation = json['passwordConfirmation'] as String?;

Map<String, dynamic> _$UserInsertRequestToJson(UserInsertRequest instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'dateOfBirth': instance.dateOfBirth?.toIso8601String(),
      'cityName': instance.cityName,
      'jmbg': instance.jmbg,
      'gender': instance.gender,
      'email': instance.email,
      'username': instance.username,
      'password': instance.password,
      'passwordConfirmation': instance.passwordConfirmation,
    };
