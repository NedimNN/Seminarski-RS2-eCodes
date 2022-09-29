import 'package:json_annotation/json_annotation.dart';


part 'person.g.dart';


@JsonSerializable()
class Person{
  
  int? personId;
  String? firstName;
  String? lastName;
  DateTime? dateOfBirth;
  String? cityName;
  String? jmbg;
  String? gender;

  Person(){

  }

  factory Person.fromJson(Map<String, dynamic> json) => _$PersonFromJson(json);

  /// Connect the generated [_$PersonToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PersonToJson(this);

}


