SELECT
st.name AS [Name],
sst.name AS [Schema],
baset.name AS [SystemType],
CAST(CASE WHEN baset.name IN (N'nchar', N'nvarchar') AND st.max_length <> -1 THEN st.max_length/2 ELSE st.max_length END AS int) AS [Length],
CAST(st.precision AS int) AS [NumericPrecision],
CAST(st.scale AS int) AS [NumericScale],
st.is_nullable AS [Nullable]
FROM
sys.types AS st
INNER JOIN sys.schemas AS sst ON sst.schema_id = st.schema_id
LEFT OUTER JOIN sys.types AS baset ON baset.user_type_id = st.system_type_id and baset.user_type_id = baset.system_type_id
WHERE
(st.schema_id!=4 and st.system_type_id!=240 and st.user_type_id != st.system_type_id)
ORDER BY
[Schema] ASC,[Name] ASC