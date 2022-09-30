import 'package:json_annotation/json_annotation.dart';



part 'user_insert_request.g.dart';

@JsonSerializable()
class UserInsertRequest{

  String? firstName;
  String? lastName;
  DateTime? dateOfBirth;
  String? cityName;
  String? jmbg;
  String? gender;
  String? email;
  String? username;
  String? password;
  String? passwordConfirmation;

  UserInsertRequest(){

  }
factory UserInsertRequest.fromJson(Map<String, dynamic> json) => _$UserInsertRequestFromJson(json);

  /// Connect the generated [_$UserInsertRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$UserInsertRequestToJson(this);


}
