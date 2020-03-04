import xlrd

list_file = "all_letters_final.txt"
excel_file = "all_letters_shortlist.xls" 

final_letter_list = []
excel_letter_list = []

file = open(list_file, "r", encoding="utf8") 
for line in file:
    # print(line.strip())
    final_letter_list.append(line.strip())

print (len(final_letter_list))


excel_letter_wb = xlrd.open_workbook(excel_file)

matched = 0
for s in range(1):
    sheet = excel_letter_wb.sheet_by_index(s)
    rows = sheet.nrows
    # print (rows)
    for row in range(1, rows):
        # Headline in column 1, Details in column 2
        letter = sheet.cell(row, 0).value
        # print(letter)
        excel_letter_list.append(letter)

outfile = "compare.txt"
of = open(outfile, 'w', encoding="utf8")


for l in range(1500, 2000):
    letter = final_letter_list[l]
    # print("%s : %s" % (final_letter_list[l], excel_letter_list[l]))
    of.write("%d - %s : %s\n" % (l, final_letter_list[l], excel_letter_list[l]))

of.close()

# print(str(matched))