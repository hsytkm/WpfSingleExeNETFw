# [WPF] SingleExe on .NET Fw

2023.5.4(GW) ~

### �ړI

.NET Fw ���� WPF�A�v�� ��P��exe�t�@�C���ɂł��邩��m�肽���B

### �w�i

- .NET ���ł���΃I�v�V����1�ŒP��t�@�C���𐶐��ł��܂����A.NET Fw �̔z�z�̎�y���ɂ͖��͂�����܂��B�i�����^�C����K�v�Ƃ����A�P��exe �� ���T�C�Y�Ŕz�z�ł��܂��B�j

- �T�|�[�g�I������ �ŐV .NET ���� .NETFw �̕��������A���p�A�v���̑I�����ɂȂ蓾�܂��B�iMS����͐�������Ă��܂���j

### �����܂Ƃ�

�ꌾ�ŏ����ƁA.NET Fw �ŒP��t�@�C�������Ȃ� [MahApps](https://github.com/MahApps/MahApps.Metro) �̎g�p�͂�����߂悤�B

**���܂��������_**

- ���^���� csproj �ŒP��t�@�C�����쐬�ł��܂����B

- �V�`���� csproj �ł� **~~MahApps �𓱓����Ȃ����~~**�A �P��t�@�C�����쐬�ł��܂����B

  **MahApps �𓱓�����ƃr���h�G���[���������܂��� exe �͐�������Ă���A�t�@�C���P�̂œ��삵�܂����B**

  > �G���[	MSB3030	�t�@�C�� "obj\Debug\net48\de\WpfNewCsproj.resources.dll" �͌�����Ȃ��������߃R�s�[�ł��܂���B	WpfNewCsproj	C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\amd64\Microsoft.Common.CurrentVersion.targets	4786	

**���܂������Ȃ������_**

- ���^����csproj �ł� �\�[�X�W�F�l���[�^�����삵�܂���ł����BCommunityToolKit �� ViewModel �� .NETStandard2.0 �̕ʃv���W�F�N�g�ɕ����邱�ƂőΉ����܂����B

- �V�`����csproj + MahApps �ŒP��t�@�C���̃r���h���ʂ�܂���ł����B MahApps �� `Culture=de` �ɂ��邱�Ƃ������̂悤�ł��B [for the ColorPicker name - Issue #2315](https://github.com/MahApps/MahApps.Metro/issues/2315#issuecomment-914944785)

### �P��t�@�������̃t���[�`���[�g

��₱���� + Mermaid ���g���Ă݂��������̂Ő������܂����B


```mermaid
flowchart TD
A[Can create single exe?]
A --> B[.NET Framework]
B --> |"No"| C[Can publish!]
B --> |"Yes"| D[Format of csproj]
D --> |"Old"| C
D --> |"New"| F[Use MahApps]
F --> |"No"| C
F --> |"Yes"| H[Can publish but get a MSBuild error MSB3030]

```

### �����Œm�������ǎ����Ŏ����Ă��Ȃ�����

- Microsoft�����c�[���� [ILMerge](http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx) ���g�p����� .NET �A�Z���u����P��t�@�C���Ƀ}�[�W�ł��邻���ł����AXAML ���܂܂�� WPF �ɂ͑Ή����Ă��Ȃ��炵���ł��B
- ���񎎂������@�� �������[�h�A�Z���u�� ���Ƃ��܂��s���Ȃ��炵���B(C++/CLI �ƌ����ł��Ȃ����Ă��Ƃ��Ǝv����) 

### �t���[�����[�N��r

.NET Fw �̃��W���[�o�[�W������ �����[�X���� 10�N �T�|�[�g����邻���ŁA.NET LTS�ł� 3�N �Ɣ�r���Ē����ł��B

���̃����[�X�v�悪�p�������ꍇ�A2025�N�����[�X�� .NET10 (LTS) �̊����� 2028�N �ƂȂ�A���̏ꍇ�ł� .NET Fw 4.8 �̃T�|�[�g�����i2029�N�\��j�̕��������Ȃ�܂��B


|               | ����                     | Windows�v���C���X�g�[�� | �����[�X��         | �T�|�[�g����       |
| ------------- | ------------------------ | ----------------------- | ------------------ | ------------------ |
| .NET 8 (�\��) | ����LTS                  | �Ȃ�                    | ���� (2023�N11��?) | ���� (2026�N11��?) |
| .NET 6        | ���݂�LTS                | �Ȃ�                    | 2021�N11��         | 2024�N11��         |
| .NET Fw 4.8.1 | �ŐV��Fw                 | �Ȃ�                    | 2022�N8��9��       | ���� (2032�N?)     |
| .NET Fw 4.8   | Win11�v���C���X�g�[��    | Win10, 11               | 2019�N4��18��      | ���� (2029�N?)     |
| .NET Fw 4.6.2 | �T�|�[�g�I�����\�ς݂�Fw | Win10                   | 2016�N8��2��       | 2027�N1��12��      |

### References

[WPF�A�v���P�[�V������EXE�ЂƂɂ܂Ƃ߂� - secretbase.log](https://cointoss.hatenablog.com/entry/2017/02/21/121209)

[Combining multiple assemblies into a single EXE for a WPF application | DigitallyCreated](http://www.digitallycreated.net/Blog/61/combining-multiple-assemblies-into-a-single-exe-for-a-wpf-application)

