# PromotionEngine
A simple promotion engine for calculating discounts on a cart

With more time I would have liked to:

* Improve test coverage.
* Refactor some of the tests to be data driven Theories rather than having to repeat the same Facts with different data.
* Currently all rules that match are executed. It would be nice to extend the RuleEngine so that the Rule objects themselves could be composed conditionally or executed in priority order.
* Add a method to define and retrieve rules dynamically so that new promotions can be added without needing to rebuild.
