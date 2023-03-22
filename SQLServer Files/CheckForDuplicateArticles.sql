select * from Articles

-- Save for testing - check for duplicate rows
SELECT link,COUNT(*) as Count
FROM Articles
GROUP BY link
HAVING COUNT(*) > 1