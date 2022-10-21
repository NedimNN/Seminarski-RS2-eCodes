import 'package:collection/collection.dart';
import 'package:ecodes_mobile/model/cart.dart';
import 'package:flutter/widgets.dart';

import '../model/product.dart';


class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Product product) {
    if (findInCart(product) != null) {
      findInCart(product)?.count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }
    cart.PriceToPay += product.price!;
    cart.currencyId = product.productType?.currencyId;
    notifyListeners();
  }

  removeFromCart(Product product) {
    if (findInCart(product)!.count > 1) {
      findInCart(product)?.count--;
    } else{
      cart.items.removeWhere((item) => item.product.productId == product.productId);
    }
    cart.PriceToPay -= product.price!;
    notifyListeners();
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.productId == product.productId);
    return item;
  }
}