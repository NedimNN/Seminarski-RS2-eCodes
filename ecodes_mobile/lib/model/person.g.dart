// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'person.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Person _$PersonFromJson(Map<String, dynamic> json) => Person()
  ..personId = json['personId'] as int?
  ..firstName = json['firstName'] as String?
  ..lastName = json['lastName'] as String?
  ..dateOfBirth = json['dateOfBirth'] == null
      ? null
      : DateTime.parse(json['dateOfBirth'] as String)
  ..cityName = json['cityName'] as String?
  ..jmbg = json['jmbg'] as String?
  ..gender = json['gender'] as String?;

Map<String, dynamic> _$PersonToJson(Person instance) => <String, dynamic>{
      'personId': instance.personId,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'dateOfBirth': instance.dateOfBirth?.toIso8601String(),
      'cityName': instance.cityName,
      'jmbg': instance.jmbg,
      'gender': instance.gender,
    };
