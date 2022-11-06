import 'package:ecodes_mobile/providers/base_provider.dart';

import '../model/notification.dart';

class NotificationProvider extends BaseProvider<Notif>{
  NotificationProvider():super("Notifications"){

  }

@override
  Notif fromJson(data) {
    // TODO: implement fromJson
    return Notif.fromJson(data);
  }

}