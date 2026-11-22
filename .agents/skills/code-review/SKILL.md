---
name: code-review
description: Review code changes for correctness, regressions, and maintainability issues.
---

# Code Review

Review the proposed changes against their surrounding code and stated requirements. Focus on actionable defects introduced by the changes, including incorrect behavior, regressions, missing edge cases, and security issues. For this .NET service-locator library, pay particular attention to service resolution behavior, keyed registrations, and compatibility with the Microsoft dependency-injection abstractions.

Do not modify files while performing a review. Do not report pre-existing issues, speculative concerns, or style preferences as findings. Verify each concern against the code and tests, and report only findings that can be acted on.

List findings from highest to lowest severity. For each finding, provide a severity, a precise file and line reference, and a concise explanation of the impact and conditions needed to reproduce it. If there are no actionable findings, state that explicitly.
