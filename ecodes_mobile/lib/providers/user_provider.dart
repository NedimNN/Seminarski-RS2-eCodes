import '../model/user.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("Buyers");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }
}
