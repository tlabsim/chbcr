import pickle
import xlrd
import os

graphemes = {}

graphemes_xls = xlrd.open_workbook("grapheme_map.xls")
sheet = graphemes_xls.sheet_by_index(0)
rows = sheet.nrows
cols = sheet.ncols
print ([rows, cols])

for row in range(1, rows):
    # Headline in column 1, Details in column 2
    letter = sheet.cell(row, 0).value
    english_form = sheet.cell(row, 1).value
    is_digit = sheet.cell(row, 2).value
    is_vowel = sheet.cell(row, 3).value
    is_consonant = sheet.cell(row, 5).value
    is_compound = sheet.cell(row, 5).value

    digit_index = 0 # index: 0 = non digit
    for col in range(6, 16):
        val = sheet.cell(row, col).value
        if val == 1:
            digit_index = col - 6 + 1
            break

    vowel_index = 0 # index: 0 = non vowel
    for col in range(16, 29):
        val = sheet.cell(row, col).value
        if val == 1:
            vowel_index = col - 16 + 1
            break

    consonant_index = 0 # index: 0 = non consonant
    for col in range(29, 68):
        val = sheet.cell(row, col).value
        if val == 1:
            consonant_index = col - 29 + 1
            break

    consonant_join_index = 0 # index: 0 = no consonant join
    for col in range(68, 101):
        val = sheet.cell(row, col).value
        if val == 1:
            consonant_join_index = col - 68 + 1
            break

    consonant_allograph_index = 0  # index: 0 = no consonant allograph
    for col in range(101, 107):
        val = sheet.cell(row, col).value
        if val == 1:
            consonant_allograph_index = col - 101 + 1
            break

    consonant_allograph2_index = 0  # index: 0 = no consonant allograph
    for col in range(107, 108):
        val = sheet.cell(row, col).value
        if val == 1:
            consonant_allograph_index = col - 107 + 1
            break

    consonant_diacritic_index = 0  # index: 0 = no consonant discritic [ref, hasant, chadra-bindu]
    for col in range(108, 111):
        val = sheet.cell(row, col).value
        if val == 1:
            consonant_diacritic_index = col - 108 + 1
            break


    vowel_allograph_index = 0  # index: 0 = no consonant allograph
    for col in range(111, 121):
        val = sheet.cell(row, col).value
        if val == 1:
            vowel_allograph_index = col - 111 + 1
            break

    grapheme_data = {
        'id': row,
        'grapheme': letter,
        'english_form': english_form,
        'is_digit': is_digit,
        'is_vowel': is_vowel,
        'is_consonant': is_consonant,
        'is_compound': is_compound,
        'digit_index': digit_index,
        'vowel_index': vowel_index,
        'consonant_index': consonant_index,
        'consonant_join_index': consonant_join_index,
        'consonant_allograph_index': consonant_allograph_index,
        'consonant_allograph2_index': consonant_allograph2_index,
        'consonant_diacritic_index': consonant_diacritic_index,
        'vowel_allograph_index': vowel_allograph_index
    }

    # print(letter_data)
    graphemes[row] = grapheme_data

# print(graphemes)

pickled_out = open('grapheme_map.pickle', 'wb')
pickle.dump(graphemes, pickled_out)
pickled_out.close()

# pickled_in = open('grapheme_map.pickle', 'rb')
# ltt = pickle.load(pickled_in)
# print("Unpickled: ==============")
# print(ltt)
# print(ltt[2100])
# pickled_in.close()