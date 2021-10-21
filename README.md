# PromotionEngine
A simple promotion engine for calculating discounts on a cart.

Based on the brief:
* The Cart stores the Sku IDs as a list of strings. Unit prices are defined as a dictionary of strings that represent Sku IDs and decimal values. Otherwise I would have used Sku & CartItem objects.
* The PromotionRule object is flexible and should we need to pass in more info it's simple to add new types.
* The PromotionEngine is agnostic to the concrete implementation of the rules it executes.
* The Cart is agnostic to the implementation of the PromotionEngine, for example it'd be simple to add a new engine that discounts items by 50% if the day is Thursday.

With more time I would have liked to:
* Improve test coverage.
* Add more docstrings to improve usability for consumers of the objects.
* Refactor some of the tests to be data driven Theories rather than having to repeat the same Facts with different data.
* Currently all rules that match are executed. It would be nice to extend the RuleEngine so that the Rule objects themselves could be composed conditionally or executed in priority order.
* Add a method to define and retrieve rules dynamically so that new promotions can be added without needing to rebuild.
