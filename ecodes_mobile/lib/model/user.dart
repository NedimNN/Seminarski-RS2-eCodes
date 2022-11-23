import './person.dart';
import 'package:json_annotation/json_annotation.dart';



part 'user.g.dart';

@JsonSerializable(explicitToJson: true)
class User{
  int? buyerId;
  DateTime? registrationDate;
  String? email;
  String? username;
  String? password;
  String? passwordConfirmation;
  bool? status;
  Person? person;

  User(){

  }

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  /// Connect the generated [_$UserToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$UserToJson(this);

}