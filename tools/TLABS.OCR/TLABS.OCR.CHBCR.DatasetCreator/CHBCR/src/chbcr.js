var TLABS = {}
TLABS.CHBCR = {}

TLABS.CHBCR.Test = {
  data: {
    digits: [
      {
        id: 0,
        form: '০'
      },
      {
        id: 1,
        form: '১'
      },
      {
        id: 2,
        form: '২'
      },
      {
        id: 3,
        form: '৩'
      },
      {
        id: 4,
        form: '৪'
      },
      {
        id: 5,
        form: '৫'
      },
      {
        id: 6,
        form: '৬'
      },
      {
        id: 7,
        form: '৭'
      },
      {
        id: 8,
        form: '৮'
      },
      {
        id: 9,
        form: '৯'
      }
    ],

    vowels: [
      {
        id: 0,
        form: 'অ'
      },
      {
        id: 1,
        form: 'আ'
      },
      {
        id: 2,
        form: 'ই'
      },
      {
        id: 3,
        form: 'ঈ'
      },
      {
        id: 4,
        form: 'উ'
      },
      {
        id: 5,
        form: 'ঊ'
      },
      {
        id: 6,
        form: 'ঋ'
      },
      {
        id: 7,
        form: 'এ'
      },
      {
        id: 8,
        form: 'ঐ'
      },
      {
        id: 9,
        form: 'ও'
      },
      {
        id: 10,
        form: 'ঔ'
      },
      {
        id: 11,
        form: 'অ্যা'
      },
      {
        id: 12,
        form: 'এ্যা'
      }
    ],

    consonants: [
      {
        id: 0,
        form: 'k',
        allow_join_with: [0, 10, 15, 29, 30],
        allowed_consonant_allographs: [2, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 1,
        form: 'kH',
        allow_join_with: [],
        allowed_consonant_allographs: [6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 2,
        form: 'g',
        allow_join_with: [2, 18],
        allowed_consonant_allographs: [0, 1, 2, 3, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 3,
        form: 'gH',
        allow_join_with: [],
        allowed_consonant_allographs: [1, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 4,
        form: 'Ng',
        allow_join_with: [0, 1, 2, 3, 32],
        allowed_consonant_allographs: [3],
        allowed_consonant_prefix_suffixes: [2]
      },
      {
        id: 5,
        form: 'c',
        allow_join_with: [5, 6, 9],
        allowed_consonant_allographs: [2, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 6,
        form: 'cH',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 7,
        form: 'j',
        allow_join_with: [7, 8, 9],
        allowed_consonant_allographs: [2, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 8,
        form: 'jH',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 9,
        form: 'NG',
        allow_join_with: [5, 6, 7, 8],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      },
      {
        id: 10,
        form: 'T',
        allow_join_with: [10],
        allowed_consonant_allographs: [2, 3, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 11,
        form: 'TH',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 12,
        form: 'D',
        allow_join_with: [12],
        allowed_consonant_allographs: [2, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 13,
        form: 'DH',
        allow_join_with: [],
        allowed_consonant_allographs: [5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 14,
        form: 'N',
        allow_join_with: [10, 11, 12, 13],
        allowed_consonant_allographs: [0, 2, 3, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 15,
        form: 't',
        allow_join_with: [15, 16],
        allowed_consonant_allographs: [1, 3, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 16,
        form: 'tH',
        allow_join_with: [],
        allowed_consonant_allographs: [2, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 17,
        form: 'd',
        allow_join_with: [17, 18, 23],
        allowed_consonant_allographs: [2, 3, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 18,
        form: 'dH',
        allow_join_with: [],
        allowed_consonant_allographs: [1, 2, 3, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 19,
        form: 'n',
        allow_join_with: [10, 11, 12, 15, 16, 17, 18, 30],
        allowed_consonant_allographs: [1, 2, 3, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 20,
        form: 'p',
        allow_join_with: [10, 15, 20, 30],
        allowed_consonant_allographs: [1, 2, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 21,
        form: 'pH',
        allow_join_with: [],
        allowed_consonant_allographs: [4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 22,
        form: 'b',
        allow_join_with: [7, 17, 18, 22],
        allowed_consonant_allographs: [4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 23,
        form: 'V',
        allow_join_with: [],
        allowed_consonant_allographs: [2, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 24,
        form: 'm',
        allow_join_with: [16, 20, 21, 22, 23],
        allowed_consonant_allographs: [1, 3, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 25,
        form: 'z',
        allow_join_with: [],
        allowed_consonant_allographs: [5],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 26,
        form: 'r',
        allow_join_with: [],
        allowed_consonant_allographs: [6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 27,
        form: 'l',
        allow_join_with: [0, 2, 10, 12, 20, 22, 23],
        allowed_consonant_allographs: [3, 4, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 28,
        form: 'S',
        allow_join_with: [5, 6, 15],
        allowed_consonant_allographs: [1, 2, 3, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 29,
        form: 'SH',
        allow_join_with: [0, 10, 11, 20, 21],
        allowed_consonant_allographs: [0, 2, 3, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 30,
        form: 's',
        allow_join_with: [0, 1, 10, 15, 16, 20, 21],
        allowed_consonant_allographs: [1, 2, 3, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 31,
        form: 'h',
        allow_join_with: [],
        allowed_consonant_allographs: [0, 1, 2, 3, 4, 5, 6],
        allowed_consonant_prefix_suffixes: [0, 1, 2]
      },
      {
        id: 32,
        form: 'R',
        allow_join_with: [2],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      },
      {
        id: 33,
        form: 'RH',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      },
      {
        id: 34,
        form: 'Y',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      },
      {
        id: 35,
        form: 'ৎ',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      },
      {
        id: 36,
        form: 'ং',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      },
      {
        id: 37,
        form: 'ঃ',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      },
      {
        id: 38,
        form: 'ঁ',
        allow_join_with: [],
        allowed_consonant_allographs: [],
        allowed_consonant_prefix_suffixes: []
      }
    ],

    consonant_joins: [
      {
        id: 0,
        form: 'k'
      },
      {
        id: 1,
        form: 'kH'
      },
      {
        id: 2,
        form: 'g'
      },
      {
        id: 3,
        form: 'gH'
      },
      {
        id: 4,
        form: 'Ng'
      },
      {
        id: 5,
        form: 'c'
      },
      {
        id: 6,
        form: 'cH'
      },
      {
        id: 7,
        form: 'j'
      },
      {
        id: 8,
        form: 'jH'
      },
      {
        id: 9,
        form: 'NG'
      },
      {
        id: 10,
        form: 'T'
      },
      {
        id: 11,
        form: 'TH'
      },
      {
        id: 12,
        form: 'D'
      },
      {
        id: 13,
        form: 'DH'
      },
      {
        id: 14,
        form: 'N'
      },
      {
        id: 15,
        form: 't'
      },
      {
        id: 16,
        form: 'tH'
      },
      {
        id: 17,
        form: 'd'
      },
      {
        id: 18,
        form: 'dH'
      },
      {
        id: 19,
        form: 'n'
      },
      {
        id: 20,
        form: 'p'
      },
      {
        id: 21,
        form: 'pH'
      },
      {
        id: 22,
        form: 'b'
      },
      {
        id: 23,
        form: 'V'
      },
      {
        id: 24,
        form: 'm'
      },
      {
        id: 25,
        form: 'z'
      },
      {
        id: 26,
        form: 'r'
      },
      {
        id: 27,
        form: 'l'
      },
      {
        id: 28,
        form: 'S'
      },
      {
        id: 29,
        form: 'SH'
      },
      {
        id: 30,
        form: 's'
      },
      {
        id: 31,
        form: 'h'
      },
      {
        id: 32,
        form: 'kSH'
      }
    ],

    consonant_allographs: [
      {
        id: 0,
        group: 0,
        name: 'NA-fola',
        form: 'N',
        disallowed_vowel_allographs: []
      },
      {
        id: 1,
        group: 0,
        name: 'na-fola',
        form: 'n',
        disallowed_vowel_allographs: []
      },
      {
        id: 2,
        group: 0,
        name: 'ba-fola',
        form: 'W',
        disallowed_vowel_allographs: [2, 3, 4, 5, 7, 8, 9]
      },
      {
        id: 3,
        group: 0,
        name: 'ma-fola',
        form: 'm',
        disallowed_vowel_allographs: []
      },
      {
        id: 4,
        group: 0,
        name: 'la-fola',
        form: 'l',
        disallowed_vowel_allographs: []
      },
      {
        id: 5,
        group: 1,
        name: 'ra-fola',
        form: 'r',
        disallowed_vowel_allographs: [2, 7, 8, 9]
      },
      {
        id: 6,
        group: 2,
        name: 'ja-fola',
        form: 'Z',
        disallowed_vowel_allographs: [2, 4, 5, 7, 8, 9]
      }
    ],

    // কারাদি - কারান্ত (রেফ + চন্দ্রবিন্দু)
    consonant_prefix_suffixes: [
      {
        id: 0,
        name: 'ref',
        prefix: 'rr',
        suffix: '',
        disallowed_consonant_allographs: [5],
        disallowed_vowel_allographs: [2, 7, 8, 9]
      },
      {
        id: 1,
        name: 'chandra-bindu',
        prefix: '',
        suffix: '^',
        disallowed_consonant_allographs: [],
        disallowed_vowel_allographs: [2, 4, 5, 7, 9]
      },
      {
        id: 2,
        name: 'hasant',
        prefix: '',
        suffix: ',,',
        disallowed_consonant_allographs: [],
        disallowed_vowel_allographs: [2, 4, 5, 7, 9]
      }
    ],

    vowel_allographs: [
      {
        id: 0,
        name: '',
        form: 'a',
        exclude: []
      },
      {
        id: 1,
        name: '',
        form: 'i',
        exclude: []
      },
      {
        id: 2,
        name: '',
        form: 'I',
        exclude: []
      },
      {
        id: 3,
        name: '',
        form: 'u',
        exclude: []
      },
      {
        id: 4,
        name: '',
        form: 'U',
        exclude: []
      },
      {
        id: 5,
        name: '',
        form: 'rri',
        exclude: [4, 9, 26, 32, 33, 34]
      },
      {
        id: 6,
        name: '',
        form: 'e',
        exclude: []
      },
      {
        id: 7,
        name: '',
        form: 'OI',
        exclude: []
      },
      {
        id: 8,
        name: '',
        form: 'O',
        exclude: []
      },
      {
        id: 9,
        name: '',
        form: 'OU',
        exclude: []
      }
    ],

    special_compound_letters: [
      ['ক্ট্র', 'kTr', 0, -1, [5], -1, []],
      ['ক্ত্র', 'ktr', 0, 15, [5], -1, []],
      ['ক্ষ্ণ', 'kShN', 0, 29, [0], -1, []],
      ['ক্ষ্ব', 'kShW', 0, 29, [2], -1, []],
      ['ক্ষ্ম', 'kShm', 0, 29, [3], -1, [1, 2]],
      ['ক্ষ্ম্য', 'kShmZ', 0, 29, [3, 6], -1, []],
      ['ক্ষ্য', 'kShZ', 0, 29, [6], -1, []],
      ['গ্ধ্য', 'gdhZ', 2, 18, [6], -1, []],
      ['গ্ধ্র', 'gdhr', 2, 18, [5], -1, [2]],
      ['গ্ন্য', 'gnZ', 2, 19, [6], -1, [0, 3]],
      ['গ্র্য', 'grZ', 2, 26, [6], -1, [0]],
      // ['ঙ্‌ক্ত = ঙ + ক + ত; যেমন- পঙ্‌ক্তি ','', 0, -1, [], -1, []],
      ['ঙ্ক্য', 'NgkZ', 4, 0, [6], -1, []],
      ['ঙ্ক্ষ', 'NgkSh', 4, 32, [], -1, []],
      ['ঙ্গ্য', 'NggZ', 4, 2, [6], -1, [0, 8]],
      ['ঙ্ঘ্য', 'NgghZ', 4, 3, [6], -1, [1]],
      ['ঙ্ঘ্র', 'Ngghr', 4, 3, [5], -1, [1]],
      ['চ্ছ্ব', 'cchW', 5, 6, [2], -1, [0]],
      ['চ্ছ্র', 'cchr', 5, 6, [5], -1, [0]],
      ['জ্জ্ব', 'jjw', 7, 7, [2], -1, [2]],
      ['ণ্ঠ্য', 'NThZ', 14, 11, [6], -1, [2]],
      ['ণ্ড্য', 'NDZ', 14, 12, [6], -1, []],
      ['ণ্ড্র', 'NDr', 14, 12, [5], -1, []],
      ['ত্ত্ব', 'ttW', 15, 15, [2], -1, [0]],
      ['ত্ত্য', 'ttZ', 15, 15, [6], -1, []],
      ['ত্ম্য', 'tmZ', 15, 24, [6], -1, []],
      ['ত্র্য', 'trZ', 15, 26, [6], -1, [0, 6]],
      ['দ্দ্ব', 'ddW', 17, 17, [2], -1, [0]],
      ['দ্ভ্র', 'dVr', 17, 23, [5], -1, [0]],
      ['দ্র্য', 'drZ', 17, 26, [6], -1, [0]],
      ['ন্ট্র', 'nTr', 19, 10, [5], -1, [8]],
      ['ন্ড্র', 'nDr', 19, 12, [5], -1, [6, 8]],
      ['ন্ত্ব', 'ntW', 19, 15, [2], -1, []],
      ['ন্ত্য', 'ntZ', 19, 15, [6], -1, []],
      ['ন্ত্র', 'ntr', 19, 15, [5], -1, [1, 2]],
      ['ন্ত্র্য', 'ntrZ', 19, 15, [5, 6], -1, [2]],
      ['ন্থ্র', 'nthr', 19, 16, [5], -1, [0, 1, 2]],
      ['ন্দ্য', 'ndZ', 19, 17, [6], -1, []],
      ['ন্দ্ব', 'ndW', 19, 17, [2], -1, []],
      ['ন্দ্র', 'ndr', 19, 17, [5], -1, [0, 1, 2]],
      ['ন্ধ্য', 'ndhZ', 19, 18, [6], -1, [0]],
      ['ন্ধ্র', 'ndhr', 19, 18, [5], -1, [2]],
      ['প্র্য', 'prZ', 20, 26, [6], -1, [0]],
      ['ম্প্র', 'mpr', 22, 20, [5], -1, [0, 1, 2]],
      ['ম্ব্র', 'mbr', 22, 22, [5], -1, [6]],
      ['ম্ভ্র', 'mVr', 22, 23, [5], -1, []],
      ['র্ক্য', 'rrkZ', 0, -1, [6], 0, []],
      ['র্গ্য', 'rrgZ', 2, -1, [6], 0, []],
      ['র্ঘ্য', 'rrghZ', 3, -1, [6], 0, []],
      ['র্চ্য', 'rrcZ', 5, -1, [6], 0, []],
      ['র্জ্য', 'rrjZ', 7, -1, [6], 0, []],
      ['র্ণ্য', 'rrNZ', 14, -1, [6], 0, []],
      ['র্ত্য', 'rrtZ', 15, -1, [6], 0, []],
      ['র্থ্য', 'rrthZ', 16, -1, [6], 0, []],
      ['র্ব্য', 'rrbZ', 22, -1, [6], 0, []],
      ['র্ম্য', 'rrmZ', 24, -1, [6], 0, []],
      ['র্শ্য', 'rrSZ', 28, -1, [6], 0, []],
      ['র্ষ্য', 'rrShZ', 29, -1, [6], 0, []],
      ['র্হ্য', 'rrhZ', 31, -1, [6], 0, []],
      ['র্গ্র', 'rrgr', 2, -1, [5], 0, []],
      ['র্ত্র', 'rrtr', 15, -1, [5], 0, [2]],
      ['র্দ্ব', 'rrdW', 17, -1, [2], 0, []],
      ['র্দ্র', 'rrdr', 17, -1, [5], 0, []],
      ['র্ধ্ব', 'rrDhW', 18, -1, [2], 0, []],
      ['র্শ্ব', 'rrSW', 28, -1, [2], 0, []],
      ['র্ঢ্য', 'rrDZ', 13, -1, [6], 0, []],
      ['ল্ক্য', 'lkZ', 27, 0, [6], -1, []],
      ['ষ্ক্র', 'Shkr', 29, 0, [5], -1, [0, 1]],
      ['ষ্ট্য', 'ShTZ', 29, 10, [6], -1, [0]],
      ['ষ্ট্র', 'ShTr', 29, 10, [5], -1, [0, 1, 2]],
      ['ষ্ঠ্য', 'ShThZ', 29, 11, [6], -1, [0, 4]],
      ['ষ্প্র', 'Shpr', 29, 20, [5], -1, [0]],
      ['স্ট্র', 'sTr', 30, 10, [5], -1, [0, 1, 6]],
      ['স্ত্ব', 'stW', 30, 15, [2], -1, [0, 1]],
      ['স্ত্য', 'stZ', 30, 15, [6], -1, []],
      ['স্ত্র', 'str', 30, 15, [5], -1, [0, 1, 2]],
      ['স্থ্য', 'sthZ', 30, 16, [6], -1, [6]],
      ['স্প্র', 'spr', 30, 20, [5], -1, [0, 1, 6]],
      ['স্প্‌ল', 'spl', 30, 20, [4], -1, [0, 1, 6]]
    ],

    punctuations: [
      {
        id: 0,
        name: 'Dari',
        form: '।'
      },
      {
        id: 0,
        name: 'Comma',
        form: ','
      }
    ]
  },

  all_letters: [],

  populate: function () {
    this.all_letters = Array()
    var id = 0
    var added, total = 0

    // Digits
    for (var i = 0; i < this.data.digits.length;i++) {
      var digit = this.data.digits[i]
      var letter = {}
      letter.id = id++
      letter.form = digit.form
      letter.classification_vector = this.make_classification_vector(true, false, false, false, digit.id, -1, -1, -1, [], -1, -1)
      letter.requires_transliteration = false
      this.all_letters.push(letter)
    }

    added = this.all_letters.length - total
    total = this.all_letters.length
    console.log('Added digit: ' + added)
    console.log(total)

    // Vowels
    for (var i = 0; i < this.data.vowels.length;i++) {
      var vowel = this.data.vowels[i]
      var letter = {}
      letter.id = id++
      letter.form = vowel.form
      letter.classification_vector = this.make_classification_vector(false, true, false, false, -1, vowel.id, -1, -1, [], -1, -1)
      letter.requires_transliteration = false
      this.all_letters.push(letter)
    }

    added = this.all_letters.length - total
    total = this.all_letters.length
    console.log('Added vowels: ' + added)
    console.log(total)

    // Consonants
    for (var i = 0; i < this.data.consonants.length;i++) {
      var consonant = this.data.consonants[i]
      var letter = {}
      letter.id = id++
      letter.form = consonant.form
      letter.classification_vector = this.make_classification_vector(false, false, true, false, -1, -1, consonant.id, -1, [], -1, -1)
      letter.requires_transliteration = true
      this.all_letters.push(letter)
    }

    added = this.all_letters.length - total
    total = this.all_letters.length
    console.log('Added consonants: ' + added)
    console.log(total)

    // Basic consonants with vowel allographs 
    for (var f = 0; f < 35; f++) {
      var fl = this.data.consonants[f]
      for (v = 0; v < this.data.vowel_allographs.length; v++) {
        var va = this.data.vowel_allographs[v]
        if (!va.exclude.includes(fl.id)) {
          var letter = {}
          letter.id = id++
          letter.form = fl.form + va.form
          if (!letter.form.toLowerCase().includes('rrr')) {
            letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, -1, [], -1, va.id)
            letter.requires_transliteration = true
            this.all_letters.push(letter)
          }
        }
      }
    }

    added = this.all_letters.length - total
    total = this.all_letters.length
    console.log('Added basic consonants with vowel allographs: ' + added)
    console.log(total)

    // Basic compound letters
    for (var f = 0; f < this.data.consonants.length; f++) {
      var fl = this.data.consonants[f]

      var allowed_joins = []
      if (fl.allow_join_with !== undefined && fl.allow_join_with.length > 0) {
        allowed_joins = fl.allow_join_with
      }

      if (allowed_joins.length > 0) {
        for (s = 0; s < this.data.consonant_joins.length; s++) {
          var sl = this.data.consonant_joins[s]

          if (!allowed_joins.includes(sl.id)) continue

          var letter = {}
          letter.id = id++
          letter.form = fl.form + sl.form
          letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, sl.id, [], -1, -1)
          letter.requires_transliteration = true
          this.all_letters.push(letter)
        }
      }

      var allowed_consonant_allographs = []
      if (fl.allowed_consonant_allographs !== undefined && fl.allowed_consonant_allographs.length > 0) {
        allowed_consonant_allographs = fl.allowed_consonant_allographs
      }

      if (allowed_consonant_allographs.length > 0) {
        for (var c = 0; c < this.data.consonant_allographs.length; c++) {
          var ca = this.data.consonant_allographs[c]
          if (allowed_consonant_allographs.includes(ca.id)) {
            var letter = {}
            letter.id = id++
            letter.form = fl.form + ca.form
            letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, -1, [ca.id], -1, -1)
            letter.requires_transliteration = true
            this.all_letters.push(letter)
          }
        }
      }

      var allowed_consonant_prefix_suffixes = []
      if (fl.allowed_consonant_prefix_suffixes !== undefined && fl.allowed_consonant_prefix_suffixes.length > 0) {
        allowed_consonant_prefix_suffixes = fl.allowed_consonant_prefix_suffixes
      }

      if (allowed_consonant_prefix_suffixes.length > 0) {
        for (var ps = 0; ps < 2; ps++) {
          var cps = this.data.consonant_prefix_suffixes[ps]
          if (allowed_consonant_prefix_suffixes.includes(cps.id)) {
            var letter = {}
            letter.id = id++
            letter.form = cps.prefix + fl.form + cps.suffix
            letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, -1, [], cps.id, -1)
            letter.requires_transliteration = true
            this.all_letters.push(letter)
          }
        }
      }

    // if (allowed_consonant_allographs.length > 0 && allowed_consonant_prefix_suffixes.length > 0) {
    //   for (var c = 0; c < this.data.consonant_allographs.length; c++) {
    //     var ca = this.data.consonant_allographs[c]
    //     if (allowed_consonant_allographs.includes(ca.id)) {
    //       for (var ps = 0; ps < this.data.consonant_prefix_suffixes.length; ps++) {
    //         var cps = this.data.consonant_prefix_suffixes[ps]
    //         if (!cps.disallowed_consonant_allographs.includes(ca.id) && allowed_consonant_prefix_suffixes.includes(cps.id)) {
    //           var letter = {}
    //           letter.id = id++
    //           letter.form = cps.prefix + fl.form + ca.form + cps.suffix
    //           letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, -1, [ca.id], cps.id, -1)
    //           letter.requires_transliteration = true
    //           this.all_letters.push(letter)
    //         }
    //       }
    //     }
    //   }
    // }
    }

    // হসন্ত 
    // Hasant consists two commas, so it will create problem in csv file, so it is listed separately 
    var cps = this.data.consonant_prefix_suffixes[2]
    for (var f = 0; f < this.data.consonants.length; f++) {
      var fl = this.data.consonants[f]

      var allowed_consonant_prefix_suffixes = []
      if (fl.allowed_consonant_prefix_suffixes !== undefined && fl.allowed_consonant_prefix_suffixes.length > 0) {
        allowed_consonant_prefix_suffixes = fl.allowed_consonant_prefix_suffixes
      }

      if (allowed_consonant_prefix_suffixes.includes(cps.id)) {
        var letter = {}
        letter.id = id++
        letter.form = cps.prefix + fl.form + cps.suffix
        letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, -1, [], cps.id, -1)
        letter.requires_transliteration = true
        this.all_letters.push(letter)
      }
    }

    added = this.all_letters.length - total
    total = this.all_letters.length
    console.log('Added basic compound letters: ' + added)
    console.log(total)

    // Basic consonants with consonant+vowel allographs
    for (var f = 0; f < this.data.consonants.length; f++) {
      var fl = this.data.consonants[f]

      var allowed_joins = []
      if (fl.allow_join_with !== undefined && fl.allow_join_with.length > 0) {
        allowed_joins = fl.allow_join_with
      }

      if (allowed_joins.length > 0) {
        for (var s = 0; s < this.data.consonant_joins.length; s++) {
          var sl = this.data.consonant_joins[s]

          if (allowed_joins.includes(sl.id)) {
            for (var v = 0; v < this.data.vowel_allographs.length; v++) {
              var va = this.data.vowel_allographs[v]
              var letter = {}
              letter.id = id++
              letter.form = fl.form + sl.form + va.form
              if (!letter.form.toLowerCase().includes('rrr')) {
                letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, sl.id, [], -1, va.id)
                letter.requires_transliteration = true
                this.all_letters.push(letter)
              }
            }
          }
        }
      }

      var allowed_consonant_allographs = []
      if (fl.allowed_consonant_allographs !== undefined && fl.allowed_consonant_allographs.length > 0) {
        allowed_consonant_allographs = fl.allowed_consonant_allographs
      }

      if (allowed_consonant_allographs.length > 0) {
        for (var c = 0; c < this.data.consonant_allographs.length; c++) {
          var ca = this.data.consonant_allographs[c]
          if (allowed_consonant_allographs.includes(ca.id)) {
            for (var v = 0; v < this.data.vowel_allographs.length; v++) {
              var va = this.data.vowel_allographs[v]
              if (!ca.disallowed_vowel_allographs.includes(va.id)) {
                var letter = {}
                letter.id = id++
                letter.form = fl.form + ca.form + va.form
                if (!letter.form.toLowerCase().includes('rrr')) {
                  letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, -1, [ca.id], -1, va.id)
                  letter.requires_transliteration = true
                  this.all_letters.push(letter)
                }
              }
            }
          }
        }
      }

      var allowed_consonant_prefix_suffixes = []
      if (fl.allowed_consonant_prefix_suffixes !== undefined && fl.allowed_consonant_prefix_suffixes.length > 0) {
        allowed_consonant_prefix_suffixes = fl.allowed_consonant_prefix_suffixes
      }

      if (allowed_consonant_prefix_suffixes.length > 0) {
        for (var ps = 0; ps < 2; ps++) {
          var cps = this.data.consonant_prefix_suffixes[ps]
          if (allowed_consonant_prefix_suffixes.includes(cps.id)) {
            for (var v = 0; v < this.data.vowel_allographs.length; v++) {
              var va = this.data.vowel_allographs[v]
              if (!cps.disallowed_vowel_allographs.includes(va.id)) {
                var letter = {}
                letter.id = id++
                letter.form = cps.prefix + fl.form + va.form + cps.suffix
                if (!letter.form.toLowerCase().includes('rrr')) {
                  letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fl.id, -1, [], cps.id, va.id)
                  letter.requires_transliteration = true
                  this.all_letters.push(letter)
                }
              }
            }
          }
        }
      }
    }

    added = this.all_letters.length - total
    total = this.all_letters.length
    console.log('Added compound letters with vowel allographs: ' + added)
    console.log(total)

    // Special compound letters
    for (var s = 0; s < this.data.special_compound_letters.length; s++) {
      var scl = this.data.special_compound_letters[s]
      var form = scl[1]
      var fcid = scl[2]
      var scid = scl[3]
      var cas = []
      if (scl[4] !== undefined && scl[4] instanceof Array) {
        cas = scl[4]
      }
      var cps = scl[5]
      var ava = []
      if (scl[6] !== undefined && scl[6] instanceof Array) {
        ava = scl[6]
      }

      var letter = {}
      letter.id = id++
      letter.form = form
      letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fcid, scid, cas, cps, -1)
      letter.requires_transliteration = true
      this.all_letters.push(letter)

      if (ava.length > 0) {
        for (var v = 0; v < ava.length;v++) {
          vaid = ava[v]
          if (vaid >= 0) {
            var va = this.data.vowel_allographs.find(function (e) {return e.id == vaid})
            var letter = {}
            letter.id = id++
            letter.form = form + va.form
            letter.classification_vector = this.make_classification_vector(false, false, false, true, -1, -1, fcid, scid, cas, cps, va.id)
            letter.requires_transliteration = true
            this.all_letters.push(letter)
          }
        }
      }
    }

    added = this.all_letters.length - total
    total = this.all_letters.length
    console.log('Added special compound letters: ' + added)
    console.log(total)

    return
  },

  get_all_Letters: function () {
    return this.all_letters
  },

  make_classification_vector: function (is_digit, is_vowel, is_consonant, is_joint, digit_id, vowel_id, first_consonant_id, second_consonant_id, consonant_allographs, consonant_prefix_suffix_id, vowel_allograph_id) {
    var classification_vector = ''
    var total_digits = 10
    var total_vowels = 13
    var total_consonants = 39
    var total_joinable = 33
    var total_consonant_allographs = this.data.consonant_allographs.length
    var total_consonant_prefix_suffixes = this.data.consonant_prefix_suffixes.length
    var total_vowel_allographs = 10

    classification_vector += (is_digit ? '1' : '0')
    classification_vector += ', ' + (is_vowel ? '1' : '0')
    classification_vector += ', ' + (is_consonant ? '1' : '0')
    classification_vector += ', ' + (is_joint ? '1' : '0')

    var digit_vector = Array(total_digits)
    digit_vector.fill(0)
    if (digit_id >= 0) {
      digit_vector[digit_id] = 1
    }
    classification_vector += ', ' + digit_vector.join(', ')

    var vowel_vector = Array(total_vowels)
    vowel_vector.fill(0)
    if (vowel_id >= 0) {
      vowel_vector[vowel_id] = 1
    }
    classification_vector += ', ' + vowel_vector.join(', ')

    first_consonant_vector = Array(total_consonants)
    first_consonant_vector.fill(0)
    if (first_consonant_id >= 0) {
      first_consonant_vector[first_consonant_id] = 1
    }
    classification_vector += ', ' + first_consonant_vector.join(', ')

    second_consonant_vector = Array(total_joinable)
    second_consonant_vector.fill(0)
    if (second_consonant_id >= 0) {
      second_consonant_vector[second_consonant_id] = 1
    }
    classification_vector += ', ' + second_consonant_vector.join(', ')

    consonant_allograph_vector = Array(total_consonant_allographs)
    consonant_allograph_vector.fill(0)
    if (consonant_allographs.length > 0) {
      consonant_allographs.forEach(element => {
        consonant_allograph_vector[element] = 1
      })
    }
    classification_vector += ', ' + consonant_allograph_vector.join(', ')

    consonant_prefix_suffix_vector = Array(total_consonant_prefix_suffixes)
    consonant_prefix_suffix_vector.fill(0)
    if (consonant_prefix_suffix_id >= 0) {
      consonant_prefix_suffix_vector[consonant_prefix_suffix_id] = 1
    }
    classification_vector += ', ' + consonant_prefix_suffix_vector.join(', ')

    vowel_allograph_vector = Array(total_vowel_allographs)
    vowel_allograph_vector.fill(0)
    if (vowel_allograph_id >= 0) {
      vowel_allograph_vector[vowel_allograph_id] = 1
    }
    classification_vector += ', ' + vowel_allograph_vector.join(', ')

    return classification_vector
  }
}
