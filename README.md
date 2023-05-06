# [WPF] SingleExe on .NET Fw

2023.5.4(GW) ~

## �ړI

.NET Fw ���� WPF�A�v�� ��P��exe�t�@�C���ɂł��邩��m�肽���B

## �w�i

- .NET ���ł���΃I�v�V����1�ŒP��t�@�C���𐶐��ł��܂����A.NET Fw �̔z�z�̎�y���ɂ͖��͂�����܂��B�i�����^�C����K�v�Ƃ����A�P��exe �� ���T�C�Y�Ŕz�z�ł��܂��B�j

- �T�|�[�g�I������ �ŐV .NET ���� .NETFw �̕��������A���p�A�v���̑I�����ɂȂ蓾�܂��B�iMS����͐�������Ă��܂���j

## �����܂Ƃ�

~~�ꌾ�ŏ����ƁA.NET Fw �ŒP��t�@�C�������Ȃ� [MahApps](https://github.com/MahApps/MahApps.Metro) �̎g�p�͂�����߂悤�B~~

.NET Fw �ł��P�̃t�@�C���𐶐��ł��܂��B Publish ����Ƒ��� dll ���o�͂����̂Ŏ����ŏ����܂��傤�B�i�_�T��

**���܂��������_**

- ���^���� csproj �ŒP��t�@�C�����쐬�ł��܂����B

- �V�`���� csproj �ł� **~~MahApps �𓱓����Ȃ����~~**�A �P��t�@�C�����쐬�ł��܂����B


**���܂������Ȃ������_**

- ���^����csproj �ł� �\�[�X�W�F�l���[�^�����삵�܂���ł����BCommunityToolKit �� ViewModel �� .NETStandard2.0 �̕ʃv���W�F�N�g�ɕ����邱�ƂőΉ����܂����B

### �P��t�@�������̃t���[�`���[�g

��₱���� + Mermaid ���g���Ă݂��������̂Ő������܂����B


```mermaid
flowchart TD
B[.NET Framework]
B --> |"No"| C[Can publish!]
B --> |"Yes"| D[Format of csproj]
D --> |"Old"| C
D --> |"New"| F[Use MahApps]
F --> |"No"| C
F --> |"Yes"| G[need addtional settings in csproj]
G --> C
```

### �Vcsproj + MahApps �̑Ή�����

�r���h�G���[�ō������̂őΏ��@���L�^���Ă����܂��B

**����������**

- MahApps �𓱓�����ƁiColorPicker �̃��[�J���C�Y�̂��߂Ɂj�A�r���h���ʕ��� `Culture=de` �t�H���_�����������悤�ɂȂ�܂��B[Issue #2315](https://github.com/MahApps/MahApps.Metro/issues/2315#issuecomment-914944785)

- ����ƁA�r���h���� MSBuild �� ���v���W�F�N�g���ɑ��݂��Ȃ��i�ϑz�́jdll �R�s�[���s�����Ǝ��݂āA�t�@�C�������݂��Ȃ��G���[�iMSB3030�j���������܂��B
- �܂荪�{�I�ɂ� Culture �v���ł���AMahApps �ȊO�̃��C�u���������������ɂȂ�Ǝv���܂��B
- ��L�̒ʂ�r���h�G���[�͔������܂��� exe �͍쐬����Ă���A���� exe �͒P�̂ŋN�����܂��B �Ƃ͌����A�J���G�N�X�y���G���X������������Őh���ł��c

**�Ώ��@**

csproj �ɐݒ��ǉ����邱�Ƃő΍�ł��܂����B �l�b�g�Œ��ׂĂ��iChatGPT�ɕ����Ă��j�Ώ��@��������Ȃ������̂Ŏ��͂Ő��ݏo���܂����B

```xml
<Target Name="SuppressCopyOfSelfResourceDll" BeforeTargets="ComputeIntermediateSatelliteAssemblies">
  <ItemGroup>
    <EmbeddedResource Remove="@(EmbeddedResource)" />
  </ItemGroup>
</Target>
```

**�Ώ��@�̐��ݏo����ƃ���**

1. VisualStudio �� �I�v�V���� �� �r���h���Ď��s �� MSBuild �v���W�F�N�g �r���h�̏o�͂̏ڍ�(V) �� �ŏ��i�����f�t�H�j���� �f�f�i�����ł��ׂ����j�ɕύX���܂����B

2. �R�s�[�G���[�̌����̖ϑz�̃t�@�C�� `WpfNewCsproj.resources.dll` ���ŏ��ɏo�Ă���s�𒲂ׂ�ƁA`ComputeIntermediateSatelliteAssemblies` �����ɂ���� �ϑz�t�@�C�� ���ǉ�����Ă���ۂ����Ƃ�������܂����B

3. VisualStudio �̃G���[�\�����N���b�N����� �r���h���̃X�N���v�g���\������܂��B

   > "C:\Program Files\Microsoft Visual 
   >
   > Studio\2022\Community\MSBuild\Current\Bin\amd64\Microsoft.Common.CurrentVersion.targets"

4. �r���h�X�N���v�g�� `ComputeIntermediateSatelliteAssemblies` ������� `EmbeddedResource` ���g���K�ɖϑzdll ���ǉ�����Ă��邱�Ƃ�������܂��B

5. `csproj` �� `ComputeIntermediateSatelliteAssemblies`  �̑O������ǉ����āA`EmbeddedResource` ���N���A���܂��B�i���Ȃ�͂Â��A �㏈���Ō��̏��ɖ߂��Ă��炢�܂���j

### �����Œm�������ǎ����Ŏ����Ă��Ȃ�����

- Microsoft�����c�[���� [ILMerge](http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx) ���g�p����� .NET �A�Z���u����P��t�@�C���Ƀ}�[�W�ł��邻���ł����AXAML ���܂܂�� WPF �ɂ͑Ή����Ă��Ȃ��炵���ł��B
- ���񎎂������@�� �������[�h�A�Z���u�� ���Ƃ��܂��s���Ȃ��炵���B(C++/CLI �ƌ����ł��Ȃ����Ă��Ƃ��Ǝv����) 

## �t���[�����[�N��r (2023�N5�����_)

.NET Fw �̃��W���[�o�[�W������ �����[�X���� 10�N �T�|�[�g����邻���ŁA.NET LTS�ł� 3�N �Ɣ�r���Ĕ��ɒ����ł��B

���̃����[�X�v�悪�p�������ꍇ�A2025�N�����[�X�� .NET10 (LTS) �̊����� 2028�N �ƂȂ�A���̏ꍇ�ł� .NET Fw 4.8 �̃T�|�[�g�����i2029�N�\��j�̕��������Ȃ�܂��B


|               | ����                     | Windows�v���C���X�g�[�� | �����[�X��         | �T�|�[�g����       |
| ------------- | ------------------------ | ----------------------- | ------------------ | ------------------ |
| .NET 8 (�\��) | ����LTS                  | �Ȃ�                    | ���� (2023�N11��?) | ���� (2026�N11��?) |
| .NET 6        | ���݂�LTS                | �Ȃ�                    | 2021�N11��         | 2024�N11��         |
| .NET Fw 4.8.1 | �ŐV��Fw                 | �Ȃ�                    | 2022�N8��9��       | ���� (2032�N?)     |
| .NET Fw 4.8   | Win11�v���C���X�g�[��    | Win10, 11               | 2019�N4��18��      | ���� (2029�N?)     |
| .NET Fw 4.6.2 | �T�|�[�g�I�����\�ς݂�Fw | Win10                   | 2016�N8��2��       | 2027�N1��12��      |

## References

[WPF�A�v���P�[�V������EXE�ЂƂɂ܂Ƃ߂� - secretbase.log](https://cointoss.hatenablog.com/entry/2017/02/21/121209)

[Combining multiple assemblies into a single EXE for a WPF application | DigitallyCreated](http://www.digitallycreated.net/Blog/61/combining-multiple-assemblies-into-a-single-exe-for-a-wpf-application)

