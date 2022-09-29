import 'package:ecodes_mobile/providers/base_provider.dart';

import '../model/rating.dart';

class RatingProvider extends BaseProvider<Rating>{
  RatingProvider():super("Rating"){

  }

@override
  Rating fromJson(data) {
    // TODO: implement fromJson
    return Rating.fromJson(data);
  }

}