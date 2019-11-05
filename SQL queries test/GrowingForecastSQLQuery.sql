SELECT DISTINCT
    t.ClientName,
    Month(t.Date) AS Month,    
    SUM(t.Amount) OVER (PARTITION BY t.ClientName  ORDER BY Month(t.Date) ) AS SumAmount -- оконная(аналитическая) функция
FROM Clients t
WHERE Year(t.Date) = 2017 
ORDER BY t.ClientName DESC, Month