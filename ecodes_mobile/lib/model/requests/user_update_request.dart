import 'package:json_annotation/json_annotation.dart';



part 'user_update_request.g.dart';

@JsonSerializable()
class UserUpdateRequest{

  String? firstName;
  String? lastName;
  DateTime? dateOfBirth;
  String? gender;
  String? email;
  String? password;
  String? passwordConfirmation;

  UserUpdateRequest(){

  }

  factory UserUpdateRequest.fromJson(Map<String, dynamic> json) => _$UserUpdateRequestFromJson(json);

  /// Connect the generated [_$UserUpdateRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$UserUpdateRequestToJson(this);
}