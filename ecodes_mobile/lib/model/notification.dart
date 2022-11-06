import 'package:json_annotation/json_annotation.dart';



part 'notification.g.dart';

@JsonSerializable()
class Notif{
     int? notificationId;
     String? notificationDesc; 
     DateTime? notificationDateTime; 
     int? buyerId;

  Notif(){

  }

  factory Notif.fromJson(Map<String, dynamic> json) => _$NotifFromJson(json);

  /// Connect the generated [_$NotifToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$NotifToJson(this);


}